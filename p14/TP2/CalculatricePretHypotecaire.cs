using System;
using static System.Console;
namespace CalculatricePretHypotecaire
{
    class Program
    {
        static void Main(string[] args)
        {


            bool continuer = true;

            bool valide = false;


            const string MSG_INSTRUC_MONTANT = "\nEntrez le montant de votre prêt";

            const string MSG_INSTRUC_TAUX = "\nEntrez le taux d'intérêts ( Valeur calculée sur 100 )";

            const string MSG_INSTRUC_PERIODE_AMORT = "\nEntrez votre période d'amortissement : 5, 10, 15, 20, 25 ou 30 ans";
           
            const string MSG_INSTRUC_RECOMMENCER = "\n\nSouhaitez-vous recommencer ? (O) pour Oui, (N) pour Non, ( Default = O )"; 


            string montantPretFormat = "";

            string versementMensuelFormat = ""; 

            string utilContinuer = default;


            double montantPret = default;

            double tauxInterets = default;

            double periodeAmortissement = default;

            double versementMensuel = default;


            while(continuer){

                valide = false;


                while(!valide){
                    WriteLine(MSG_INSTRUC_MONTANT);
                    valide = double.TryParse(ReadLine(), out montantPret);
                    montantPretFormat = montantPret.ToString("C");    
                }
                WriteLine($"Le montant de votre prêt est de {montantPretFormat}"); 


                valide = false;   


                while(!valide){
                    WriteLine(MSG_INSTRUC_TAUX);
                    valide = double.TryParse(ReadLine(), out tauxInterets);
                }               
                WriteLine($"Votre taux d'interêts sera de {tauxInterets}%");
 

                valide = false;


                while(!valide){
                    WriteLine(MSG_INSTRUC_PERIODE_AMORT);
                    double.TryParse(ReadLine(), out periodeAmortissement);
                    valide = periodeAmortissement % 5 == 0 && periodeAmortissement < 31;  
                }
                WriteLine($"Votre période d'amortissement sera de {periodeAmortissement} ans");

 
                versementMensuel = montantPret * ( tauxInterets / 100 ) / 12; 
                versementMensuel = versementMensuel / ( 1 - Math.Pow( 1 + (( tauxInterets / 100 ) / 12), ( -12 * periodeAmortissement) ));

                versementMensuelFormat = versementMensuel.ToString("C");
                WriteLine($"\n\nVotre versement mensuel sera de {versementMensuelFormat}");


                WriteLine(MSG_INSTRUC_RECOMMENCER);
                
                utilContinuer = ReadLine();

                if(utilContinuer == "N" || utilContinuer == "n" ){
                    continuer = false;
                }
            }

        }
    }
}
