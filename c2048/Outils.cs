using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace c2048
{
    public static class Outils
    {
        public static Dictionary<string, Color> Couleurs(int val)
        {
            Color couleurFonte = Color.Black;
            Color couleurFond = Color.White;

            switch (val)
            {
                case 2:
                    couleurFond = Color.AntiqueWhite;
                    break;
                case 4:
                    couleurFond = Color.Gold;
                    break;
                case 8:
                    couleurFond = Color.Maroon;
                    break;
                case 16:
                    couleurFond = Color.Green;
                    break;
                case 32:
                    couleurFond = Color.Cyan;
                    break;
                case 64:
                    couleurFond = Color.Turquoise;
                    break;
                case 128:
                    couleurFond = Color.DarkBlue;
                    couleurFonte = Color.GhostWhite;
                    break;
                case 256:
                    couleurFond = Color.MistyRose;
                    break;
                case 512:
                    couleurFond = Color.RosyBrown;
                    break;
                case 1024:
                    couleurFond = Color.Crimson;
                    couleurFonte = Color.GhostWhite;
                    break;
                case 2048:
                case 4096:
                case 8192:
                case 16384:
                case 32768:
                    couleurFond = Color.Firebrick;
                    couleurFonte = Color.GhostWhite;
                    break;
            }
            var couleur = new Dictionary<string, Color>
            {
                ["fonte"] = couleurFonte,
                ["fond"] = couleurFond
            };
            return couleur;
        }
    }
}
