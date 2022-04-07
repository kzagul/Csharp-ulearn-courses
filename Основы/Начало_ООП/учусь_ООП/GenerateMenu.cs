using System;
namespace учусь_ООП
{
    public class MenuItem
    {
        public string Caption;
        public string HotKey;
        public MenuItem[] items;


        public static MenuItem[] GenerateMenu()
        {
            return new[]
            {
                 new MenuItem
                 {
                     Caption = "File",
                     HotKey = "F",
                     items = new[]
                     {
                         new MenuItem {Caption = "New", HotKey = "N",},
                         new MenuItem {Caption = "Save", HotKey = "S",}
                     }

                 },
                 new MenuItem
                 {
                     Caption = "Edit",
                     HotKey = "E",
                     items = new[]
                     {
                         new MenuItem {Caption = "Copy", HotKey = "C"},
                         new MenuItem {Caption = "Paste", HotKey = "P"}
                     }
                 }

             };

        }
    }
 
}
