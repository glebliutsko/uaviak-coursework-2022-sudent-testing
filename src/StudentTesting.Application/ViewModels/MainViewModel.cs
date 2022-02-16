using StudentTesting.Application.Views.Pages;
using StudentTesting.Database;
using StudentTesting.Database.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace StudentTesting.Application.ViewModels
{
    public class MainViewModel : ViewModelBase, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;

        public MainViewModel(StudentDbContext db, User user) : base(db)
        {
            User = user;

            GenerateMenuItem();
            SelectedMenuItem = MenuItems[0];
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

        public void GenerateMenuItem()
        {
            MenuItems.Add(
                new MenuItem(
                    "Пользователи",
                    new Users(new UsersViewModel(_db))
                )
            );

            MenuItems.Add(
                new MenuItem(
                    "Тесты",
                    new Tests()
                )
            );
        }
    }
}
