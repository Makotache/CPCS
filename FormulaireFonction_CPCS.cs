using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace CPCS
{
    public static class FormulaireFonction_CPCS
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

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        /// <summary>
        /// Change la couleur des bordures du textbox
        /// </summary>
        /// <param name="textbox"></param>
        /// <param name="couleur"></param>
        /// <param name="Formulaire"></param>
        public static void ChangeCouleurBordure(TextBox textbox, Color couleur)
        {
            //récupération de l'instance de la fenêtre
            var hdc = GetWindowDC(textbox.Parent.Handle);
            Graphics g = Graphics.FromHdcInternal(hdc);
            //prépare la couleur à utiliser pour le rectangle
            Pen p = new Pen(couleur);


            //on met le formulaire dans un rectangle, car le formulaire possède deux taille différente ;
            //la taille de la fenêtre 
            //la taille du contenue de la fenêtre
            //
            //et le dessin du rectangle se base sur la taille de la fenêtre contrairement aux reste des controls.
            TailleBordureFormulaire((Form)textbox.Parent, out int bordure_haut, out int bordure_gauche_bas_droite);


            //Console.WriteLine($"ecran_en_Rectangle.Width = {ecran_en_Rectangle.Width}, ecran_en_Rectangle.Height {ecran_en_Rectangle.Height}");
            //dans le cas ou le textbox possède un tag, on le met a coté avec le 'borderStyleOriginal'
            //'borderStyleOriginal' sert a redéfiinr la valeur par défaut lors du clear de la couleur
            object[] obj = { textbox.Tag, "BorderStyle_original=" + textbox.BorderStyle.ToString() };
            
            textbox.Tag = (object)obj;
            textbox.BorderStyle = BorderStyle.None;

            //position et taille du rectangle
            Point location = new Point(textbox.Location.X + bordure_gauche_bas_droite, textbox.Location.Y + bordure_haut);
            Size size = new Size(textbox.Width, textbox.Height);
            Rectangle rec = new Rectangle(location, size);

            g.DrawRectangle(p, rec);
            Console.WriteLine($"rec.X = {rec.X}, rec.Y = {rec.Y},\n rec.Width = {rec.Width}, rec.Height = {rec.Height}");
        }

        public static void TailleBordureFormulaire(Form formulaire, out int bordure_haut, out int bordure_gauche_bas_droite)
        {
            //récupérationde la taille de la fenetre
            Size fenetre_form = formulaire.Size;
            //récupérationde la tailler du conteneur des controls de la fenetre
            Size conteneur_form = formulaire.RectangleToScreen(formulaire.ClientRectangle).Size;

            bordure_gauche_bas_droite = fenetre_form.Width - conteneur_form.Width / 2;
            bordure_haut = fenetre_form.Height - conteneur_form.Width - bordure_gauche_bas_droite;
        }

        public static void OriginalCouleurBordure(TextBox textbox)
        {
            //récupérer le rectangle pour le supprimer
            try
            {
                object[] obj = (object[])textbox.Tag;

                textbox.Tag = obj[0];
                textbox.BorderStyle = (BorderStyle)obj[1];
            }
            catch
            {
                textbox.BorderStyle = BorderStyle.Fixed3D;
            }
        }
    }
}
