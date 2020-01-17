using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c2048
{
    public partial class Jeu : Form
    {
        private int _mouvements = 0;
        private int[,] _case = new int[4,4];

        public enum Sens
        {
            Haut,
            Bas,
            Droite,
            Gauche,
            Autre
        }

        public Jeu()
        {
            InitializeComponent();
        }

        private void NouveauJeu_Click(object sender, EventArgs e)
        {
            MessageEtat("Nouvelle partie");
            _case[2, 0] = 4;
            Affiche(2, 0);
        }

        private void LabelEtat_Click(object sender, EventArgs e)
        {
            MessageEtat("Version 1.0");
        }

        private void Jeu_KeyDown(object sender, KeyEventArgs e)
        {
            Sens touche = Direction(e);
            MessageEtat($"Touche {touche}");
            if (touche != Sens.Autre && Bouge(touche))
            {
                _mouvements += 1;
                Affiche();
            }
        }

        private void MessageEtat(string message)
        {
            LabelEtat.Text = message;
        }

        private Sens Direction(KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Down: return Sens.Bas;
                case Keys.Up: return Sens.Haut;
                case Keys.Left: return Sens.Gauche;
                case Keys.Right: return Sens.Droite;
                default: return Sens.Autre;
            }
        }

        private void Jeu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MessageBox.Show(String.Format("Fermeture de l'application demandée pour {0}. Voulez-vous quitter ?", e.CloseReason), "Fermeture...", MessageBoxButtons.YesNo) == DialogResult.No;
        }
            
        private void Jeu_Load(object sender, EventArgs e)
        {

        }

        private void Affiche(int x, int y)
        {
            var ctrl = Grille.Controls.Find($"Case{x}{y}", true)[0];
            ctrl.Text = (_case[x, y] == 0) ? "" : _case[x, y].ToString();
            var couleur = Outils.Couleurs(_case[x, y]);
            ctrl.BackColor = couleur["fond"];
            ctrl.ForeColor = couleur["fonte"];
        }

        private void Affiche()
        {
            for (int i = 0; i <= 3; i +=1)
            {
                for (int j = 0; j <= 3; j += 1)
                {
                    Affiche(i, j);
                }
            }
            LabelMouvement.Text = _mouvements.ToString();
        }

        private bool Bouge(Sens s)
        {
            bool caseDeplacee = false;

            switch (s)
            {
                case Sens.Droite:
                    // pour chaque ligne
                    for (int j = 0; j <= 3; j += 1)
                    {
                        // pour chaque colonne
                        for (int i = 2; i >= 0; i -= 1)
                        {
                            if ((_case[i + 1, j] == 0) && (_case[i, j] != 0))
                            {
                                _case[i + 1, j] = _case[i, j];
                                _case[i, j] = 0;
                                caseDeplacee = true;
                            }
                        }
                    }
                    break;
                case Sens.Gauche:
                    // pour chaque ligne
                    for (int j = 0; j <= 3; j += 1)
                    {
                        // pour chaque colonne
                        for (int i = 1; i <= 3; i += 1)
                        {
                            if ((_case[i - 1, j] == 0) && (_case[i, j] != 0))
                            {
                                _case[i - 1, j] = _case[i, j];
                                _case[i, j] = 0;
                                caseDeplacee = true;
                            }
                        }
                    }
                    break;
                case Sens.Bas:
                    // pour chaque ligne
                    for (int j = 2; j >= 0; j -= 1)
                    {
                        // pour chaque colonne
                        for (int i = 0; i <= 3; i += 1)
                        {
                            if ((_case[i, j+1] == 0) && (_case[i, j] != 0))
                            {
                                _case[i, j+1] = _case[i, j];
                                _case[i, j] = 0;
                                caseDeplacee = true;
                            }
                        }
                    }
                    break;
                case Sens.Haut:
                    // pour chaque ligne
                    for (int j = 1; j <= 3; j += 1)
                    {
                        // pour chaque colonne
                        for (int i = 0; i <= 3; i += 1)
                        {
                            if ((_case[i, j-1] == 0) && (_case[i, j] != 0))
                            {
                                _case[i, j-1] = _case[i, j];
                                _case[i, j] = 0;
                                caseDeplacee = true;
                            }
                        }
                    }
                    break;
            }
            return caseDeplacee;
        }
    }
}
