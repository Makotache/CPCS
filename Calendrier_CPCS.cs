﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPCS
{
    public partial class Calendrier_CPCS : UserControl
    {
        public static readonly string[] NOM_MOIS = {"Janvier", "Février", "Mars", "Avril", "Mai", 
            "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre"};

        /// <summary>
        /// Permet de demander à l'utilisateur de saisir une date pour effectuer des traitements.
        /// </summary>
        public Calendrier_CPCS()
        {
            suppl_contructeur(1900, DateTime.Now.Year);
        }

        /// <summary>
        /// Permet de demander à l'utilisateur de saisir une date pour effectuer des traitements.
        /// </summary>
        /// <param name="annee_min">Définit l'année minimum que l'on à dans le comboBox.</param>
        /// <param name="annee_max">Définit l'année maximum que l'on à dans le comboBox.</param>
        public Calendrier_CPCS(int annee_min, int annee_max)
        {
            suppl_contructeur(annee_min, annee_max);
        }

        /// <summary>
        /// Supplément pour le contructeur.
        /// </summary>
        /// <param name="annee_min">Définit l'année minimum que l'on à dans le comboBox.</param>
        /// <param name="annee_max">Définit l'année maximum que l'on à dans le comboBox.</param>
        private void suppl_contructeur(int annee_min, int annee_max)
        {
            InitializeComponent();

            actualisationMois();
            actualisationAnnee(annee_min, annee_max);

            //on initialise le mois et l'année avant les jours
            //pour ce servir de ces valeurs lors de la récupération
            ////du nombre de mois pour la date de base
            actualisationJour();
        }

        #region actualisation

        /// <summary>
        /// Sert à l'actualisation du comboBox du Jour.
        /// </summary>
        private void actualisationJour()
        {
            int mois = mois_comboBox.SelectedIndex + 1;
            int annee = Convert.ToInt16(annee_comboBox.SelectedItem);
            int nb_jours_mois = DateTime.DaysInMonth(annee, mois);

            List<int> num_jour = new List<int>();
            for (int i = 1; i < nb_jours_mois+1; i++)
            {
                num_jour.Add(i);
            }
            jour_comboBox.DataSource = num_jour;
        }

        /// <summary>
        /// Sert à l'actualisation du comboBox du Mois.
        /// </summary>
        private void actualisationMois()
        {
            List<int> num_mois = new List<int>();
            for (int i = 1; i < 13; i++)
            {
                num_mois.Add(i);
            }
            mois_comboBox.DataSource = num_mois;
        }

        /// <summary>
        /// Sert à l'actualisation du comboBox de l'Année.
        /// </summary>
        /// <param name="annee_min">Définit l'année minimum que l'on à dans le comboBox.</param>
        /// <param name="annee_max">Définit l'année maximum que l'on à dans le comboBox.</param>
        private void actualisationAnnee(int annee_min, int annee_max)
        {
            List<int> num_annee = new List<int>();
            for (int i = annee_max; i > annee_min; i--)
            {
                num_annee.Add(i);
            }
            annee_comboBox.DataSource = num_annee;
        }
        #endregion


        #region ComboBox _SelectedIndexChanged
        private void actualisationJour(object sender, EventArgs e)
        {
            actualisationJour();
        }
        #endregion


        #region Get-Set Date

        /// <summary>
        /// Récupération de la date avec le mois sous forme d'un nombre.
        /// </summary>
        /// <returns>Format de retour = '31 / 12 / 1999'.</returns>
        public string getDateInt()
        {
            return $"{jour_comboBox.SelectedItem} / {mois_comboBox.SelectedItem} / {annee_comboBox.SelectedItem}";
        }

        /// <summary>
        /// Récupération de la date avec le mois sous forme d'un nombre.
        /// </summary>
        /// <returns>Format de retour = '31 Décembre 1999'.</returns>
        public string getDateString()
        {
            return $"{jour_comboBox.SelectedItem} {NOM_MOIS[mois_comboBox.SelectedIndex]} {annee_comboBox.SelectedItem}";
        }

        /// <summary>
        /// Définit la valeur du jour dans le comboBox associé.
        /// </summary>
        /// <param name="jour">Le jour que l'on veux définir.</param>
        /// <returns>False si le <paramref name="jour"/> n'est pas valide. Sinon True.</returns>
        public bool SetJour(int jour)
        {
            return addOn_setDate(jour, jour_comboBox);
        }

        /// <summary>
        /// Récupération de la valeur du jour.
        /// </summary>
        /// <returns>La valeur du jour sous forme d'un nombre.</returns>
        public int GetJour()
        {
            return Convert.ToInt32(jour_comboBox.SelectedItem.ToString());
        }

        /// <summary>
        /// Définit la valeur du mois dans le comboBox associé.
        /// </summary>
        /// <param name="mois">Le mois que l'on veux définir.</param>
        /// <returns>False si le <paramref name="mois"/> n'est pas valide. Sinon True.</returns>
        public bool SetMois(int mois)
        {
            return addOn_setDate(mois, mois_comboBox);
        }

        /// <summary>
        /// Récupération de la valeur du mois.
        /// </summary>
        /// <returns>La valeur du mois sous forme d'un nombre.</returns>
        public int GetMoisInt()
        {
            return mois_comboBox.SelectedIndex + 1;
        }

        /// <summary>
        /// Récupération de la valeur du mois.
        /// </summary>
        /// <returns>La valeur du mois sous forme d'une chaine de caractère.</returns>
        public string GetMoisString()
        {
            return NOM_MOIS[mois_comboBox.SelectedIndex];
        }

        /// <summary>
        /// Définit la valeur de l'année dans le comboBox associé.
        /// </summary>
        /// <param name="annee">L'année que l'on veux définir.</param>
        /// <returns>False si le <paramref name="annee"/> n'est pas valide. Sinon True.</returns>
        public bool SetAnnee(int annee)
        {
            return addOn_setDate(annee, annee_comboBox);
        }

        /// <summary>
        /// Récupération de la valeur de l'année.
        /// </summary>
        /// <returns>La valeur de l'année sous forme d'un nombre.</returns>
        public int GetAnnee()
        {
            return Convert.ToInt32(annee_comboBox.SelectedItem.ToString());
        }

        /// <summary>
        /// Permet de redéfinir la valeur du <paramref name="comboBox"/> définit en paramètre par le <paramref name="nombre"/>.
        /// </summary>
        /// <param name="nombre">Nombre à sélectionner dans le comboBox.</param>
        /// <param name="comboBox">ComboBox dans lequel est sélectionné le nombre entré en paramètre.</param>
        /// <returns>False si le nombre donnée n'existe pas dans les Items des comboBox. Sinon True.</returns>
        private bool addOn_setDate(int nombre, ComboBox comboBox)
        {
            if(comboBox.Items.Contains((object)nombre))
            {
                comboBox.SelectedItem = nombre;
                return true;
            }

            return false;
        }
        #endregion

    }
}
