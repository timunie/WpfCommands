﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCommands.Commands;
using WpfCommands.MVVM.Model;

namespace WpfCommands.MVVM.ViewModel
{
    public class ViewModelBase
    {
        private ICommand _clickCommand;

        private ICommand _clickCommand2;

        private ICommand _saveCommand;

        public ICommand ClickCommand => _clickCommand ??= new RelayCommand(param => MyActionButton1(param), param => CanExecute);

        public ICommand ClickCommand2 => _clickCommand2 ??= new RelayCommand(param => MyActionButton2(param), param => CanExecute);

        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(param => OnSaveExecute(param), param => CanSaveExecute);

        public void OnSaveExecute(object param)
        {
            if (param != null)
            {
                object[] values = (object[])param;
                if (values != null || values.Length > 0)
                {
                    SaveModel saveModel = new();
                    saveModel.Name = (string)values[0];
                    saveModel.Vorname = (string)values[1];
                    saveModel.Age = !int.TryParse((string)values[2], out int age) ? age : 0;
                    saveModel.Country = (string)values[3];

                    MessageBoxResult messageBoxResult = MessageBox.Show("Save Command Invoke und speichern von " + saveModel.Name + " " + saveModel.Vorname + " and " + saveModel.Age + " in Country " + saveModel.Country + " was initialized.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void MyActionButton2(object param)
        {
            param = "Warning Message";
            MessageBox.Show("MyAction2 was invoked. " + param, "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public bool CanExecute
        {
            get { return true; }
        }

        public bool CanSaveExecute
        {
            get { return true; }
        }


        public void MyActionButton1(object param)
        {
            param = "Test 2";
            MessageBox.Show("MyAction was invoked. " + param, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
