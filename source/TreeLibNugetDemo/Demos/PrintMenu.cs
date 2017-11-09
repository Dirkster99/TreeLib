namespace TreeLibNugetDemo.Demos
{
    using System;
    using System.Collections.Generic;

    internal class PrintMenu
    {
        #region fields
        private readonly List<MapMenu> _Menu = new List<MapMenu>();
        #endregion fields

        #region ctors
        public PrintMenu()
        {
        }
        #endregion ctors

        #region methods
        internal void AddMenuEntry(char key, string caption)
        {
            _Menu.Add(new MapMenu(key, caption));
        }

        internal char ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in _Menu)
            {
                Console.WriteLine("Key: '{0}' {1}", item.Key, item.Caption);
            }

            Console.WriteLine();
            Console.WriteLine("Press a menu key to see that demo or any other for exit.");
            Console.WriteLine();

            return Console.ReadKey().KeyChar;
        }
        #endregion methods

        #region private classes
        private class MapMenu
        {
            public MapMenu(char key, string caption)
            {
                Key = key;
                Caption = caption;
            }

            public char Key { get; private set; }

            public string Caption { get; private set; }
        }
        #endregion private classes
    }
}
