using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPCS
{
    public static class Fonction_CPCS
    {

        //pour centrer le titres des formulaires
        public static void UpdateTextPosition(Form formulaire)
        {
            Graphics g = formulaire.CreateGraphics();
            Double startingPoint = (formulaire.Width / 2) - (g.MeasureString(formulaire.Text.Trim(), formulaire.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", formulaire.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            formulaire.Text = tmp + formulaire.Text.Trim();
        }
    }
}
