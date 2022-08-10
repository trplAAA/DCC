﻿using System;
using System.Windows;
using System.Windows.Media;

namespace BespokeFusion
{
    public sealed class MaterialMessageBox
    {
        private const string MessageBoxTitle = "CheckerPlus";

        /// <summary>
        /// Displays a message box with OK button
        /// </summary>
        /// <param name="message">The message to display</param>
        public static void Show(string message)
        {
            using (var msg = new MessageBoxWindow())
            {
                msg.TxtTitle.Text = MessageBoxTitle;
                msg.TxtMessage.Text = message;
                msg.TitleBackgroundPanel.Fill = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                msg.TitleBackgroundPanel.Stroke = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                msg.BorderBrush = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                msg.BtnCancel.Visibility = Visibility.Collapsed;

                msg.BtnOk.Focus();
                msg.ShowDialog();
            }
        }

        /// <summary>
        ///  Displays a message box with OK button
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="title">The title of the message box</param>
        public static void Show(string message, string title)
        {
            using (var msg = new MessageBoxWindow())
            {
                msg.TxtTitle.Text = title;
                msg.TxtMessage.Text = message;
                msg.TitleBackgroundPanel.Fill = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                msg.TitleBackgroundPanel.Stroke = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                msg.BorderBrush = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                msg.BtnCancel.Visibility = Visibility.Collapsed;

                msg.BtnOk.Focus();
                msg.ShowDialog();
            }
        }

        /// <summary>
        /// Displays an error message box
        /// </summary>
        /// <param name="errorMessage">The error error message to display</param>
        public static void ShowError(string errorMessage)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.TxtTitle.Text = MessageBoxTitle;
                    msg.TxtMessage.Text = errorMessage;
                    msg.TitleBackgroundPanel.Fill = Brushes.Red;
                    msg.TitleBackgroundPanel.Stroke = Brushes.Red;
                    msg.BorderBrush = Brushes.Red;
                    msg.BtnCancel.Visibility = Visibility.Collapsed;

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(errorMessage);
            }
        }

        /// <summary>
        /// Displays a message box with a cancel button
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <returns>Message box Result OK or CANCEL</returns>
        public static MessageBoxResult ShowWithCancel(string message)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.TxtTitle.Text = MessageBoxTitle;
                    msg.TxtMessage.Text = message;
                    msg.TitleBackgroundPanel.Fill = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.TitleBackgroundPanel.Stroke = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.BorderBrush = new SolidColorBrush(Color.FromRgb(39, 39, 39));

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch(Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }

        /// <summary>
        /// Displays a message box with a cancel button
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="title">The title of the message box</param>
        /// <returns>Message box Result OK or CANCEL</returns>
        public static MessageBoxResult ShowWithCancel(string message, string title)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.TxtTitle.Text = title;
                    msg.TxtMessage.Text = message;
                    msg.TitleBackgroundPanel.Fill = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.TitleBackgroundPanel.Stroke = new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.BorderBrush = new SolidColorBrush(Color.FromRgb(39, 39, 39));

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }

        /// <summary>
        /// Displays a message box with a cancel button
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="isError">If the message is an error</param>
        /// <returns>Message box Result OK or CANCEL</returns>
        public static MessageBoxResult ShowWithCancel(string message, bool isError)
        {
            try
            {
                using (var msg = new MessageBoxWindow())
                {
                    msg.TxtTitle.Text = MessageBoxTitle;
                    msg.TxtMessage.Text = message;
                    msg.TitleBackgroundPanel.Fill = isError
                        ? Brushes.Red
                        : new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.BorderBrush = isError 
                        ? Brushes.Red 
                        : new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.TitleBackgroundPanel.Stroke = isError
                        ? Brushes.Red
                        : new SolidColorBrush(Color.FromRgb(39, 39, 39));
                    msg.BorderBrush = isError
                        ? Brushes.Red
                        : new SolidColorBrush(Color.FromRgb(39, 39, 39));

                    msg.BtnOk.Focus();
                    msg.ShowDialog();
                    return msg.Result == MessageBoxResult.OK ? MessageBoxResult.OK : MessageBoxResult.Cancel;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(message);
                return MessageBoxResult.Cancel;
            }
        }

    }
}
