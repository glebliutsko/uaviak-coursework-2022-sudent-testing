using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Utils;
using StudentTesting.Application.Views.Pages;
using StudentTesting.Application.Views.Windows;
using StudentTesting.Database.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace StudentTesting.Application.ViewModels
{
    public class MainViewModel : OnPropertyChangeBase, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;

        public MainViewModel(User user)
        {
            User = user;

            GenerateMenuItem();
            SelectedMenuItem = MenuItems[0];

            QuitCommand = new RelayCommand(x => Quit());
        }

        #region Property
        #region User
        private User _user;
        public User User
        {
            get => _user;
            private set
            {
                _user = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region MenuItems
        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> MenuItems
        {
            get => _menuItems;
            private set
            {
                _menuItems = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region SelectedMenuItem
        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                OnPropertyChange();

                Content = value.Content;
            }
        }
        #endregion

        #region Content
        private UIElement _content;

        public UIElement Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChange();
            }
        }
        #endregion
        #endregion

        #region Command
        public ICommand QuitCommand { get; }
        #endregion

        private void GenerateMenuItem()
        {
            if (User.Role == UserRole.TEACHER)
            {
                MenuItems.Add(
                    new MenuItem(
                        "Пользователи",
                        new Users(new UsersViewModel())
                    )
                );
                MenuItems.Add(
                    new MenuItem(
                        "Курсы",
                        null
                    )
                );
            }
            else
            {
                
            }
        }

        private void Quit()
        {
            System.Windows.Application.Current.MainWindow = new AuthorizeWindow(new AuthorizeViewModel());
            System.Windows.Application.Current.MainWindow.Show();

            OnRequestClose?.Invoke(this, new EventArgs());
        }
    }
}
