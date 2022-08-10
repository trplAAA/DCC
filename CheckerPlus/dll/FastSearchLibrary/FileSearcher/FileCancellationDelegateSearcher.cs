﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FastSearchLibrary
{
    internal class FileCancellationDelegateSearcher : FileCancellationSearcherBase
    {
        private Func<FileInfo, bool> isValid;

        public FileCancellationDelegateSearcher(string folder, Func<FileInfo, bool> isValid, CancellationToken token, ExecuteHandlers handlerOption, bool suppressOperationCanceledException)
            : base(folder, token, handlerOption, suppressOperationCanceledException)
        {
            this.isValid = isValid;
        }


        protected override void GetFiles(string folder)
        {
            token.ThrowIfCancellationRequested();

            DirectoryInfo dirInfo = null;
            DirectoryInfo[] directories = null;
            List<FileInfo> resultFiles = new List<FileInfo>();

            try
            {
                dirInfo = new DirectoryInfo(folder);
                directories = dirInfo.GetDirectories();

                if (directories.Length == 0)
                {
                    FileInfo[] files = dirInfo.GetFiles();

                    foreach (var file in files)
                        if (isValid(file))
                            resultFiles.Add(file);

                    if (resultFiles.Count > 0)
                        OnFilesFound(resultFiles);

                    return;
                }
            }
            catch (UnauthorizedAccessException )
            {
                return;
            }
            catch (PathTooLongException )
            {
                return;
            }
            catch (DirectoryNotFoundException )
            {
                return;
            }


            foreach (var d in directories)
            {
                token.ThrowIfCancellationRequested();

                GetFiles(d.FullName);
            }

            token.ThrowIfCancellationRequested();

            try
            {
                var files = dirInfo.GetFiles();

                foreach (var file in files)
                    if (isValid(file))
                        resultFiles.Add(file);

                if (resultFiles.Count > 0)
                    OnFilesFound(resultFiles);
            }
            catch (UnauthorizedAccessException )
            {
            }
            catch (PathTooLongException )
            {
            }
            catch (DirectoryNotFoundException )
            {
            }

            return;
        }



        protected override List<DirectoryInfo> GetStartDirectories(string folder)
        {
            token.ThrowIfCancellationRequested();

            DirectoryInfo dirInfo = null;
            DirectoryInfo[] directories = null;
            List<FileInfo> resultFiles = new List<FileInfo>();

            try
            {
                dirInfo = new DirectoryInfo(folder);
                directories = dirInfo.GetDirectories();

                FileInfo[] files = dirInfo.GetFiles();

                foreach (var file in files)
                    if (isValid(file))
                        resultFiles.Add(file);

                if (resultFiles.Count > 0)
                    OnFilesFound(resultFiles);

                if (directories.Length > 1)
                    return new List<DirectoryInfo>(directories);

                if (directories.Length == 0)
                    return new List<DirectoryInfo>();
            }
            catch (UnauthorizedAccessException )
            {
                return new List<DirectoryInfo>();
            }
            catch (PathTooLongException )
            {
                return new List<DirectoryInfo>();
            }
            catch (DirectoryNotFoundException )
            {
                return new List<DirectoryInfo>();
            }

            return GetStartDirectories(directories[0].FullName);
        }


    }
}
