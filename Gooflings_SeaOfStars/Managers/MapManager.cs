using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Gooflings
{
    public class MapManager
    {
        private MapTxtReader _txtReader;

        public MapManager()
        {
        }

        public void Update(Player plr, string currentMap)
        {
            MapPngReader _pngReader = new MapPngReader();
            _txtReader = new(_pngReader.UsedColor);
            _txtReader.Draw(plr, currentMap);
        }
    }
}
