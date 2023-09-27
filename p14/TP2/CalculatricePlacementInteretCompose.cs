using System;
using static System.Console;

namespace CalculatricePlacement
{
    class Program
    {
        static void Main(string[] args)
        {
           
            const string INSTRUC_DEPOT_INITIAL = "Veuillez entrer le montant du dépot initial";

            const string INSTRUC_INTERET_ANNUEL = "Veuillez entrer le taux d'interet annuel ( Valeur en pourcentage )";

            const string INSTRUC_DEPOT_MENSUEL = "Veuillez entrer le montant des depots subséquents mensuels";
            

            double depotInitial = default;

            double tauxInteretAnnuel = default;

            double depotMensuel = default;

            double montantEconomie = default;

            double nbrMoisMillionaire = default;

            double milion = 1000000;

            double interetTotal = default;

            double anneeMillionaire = default;

            double moisExtraMill = default;


            string investissementTotalFormat;

            string interetTotalFormat = default;

            string depotInitialFormat = default;

            string tauxInteretFormat = default;

            string depotMensuelFormat = default;

            string montantEconomieFormat = default;

            string ouiOuNon = "N";
            

            bool millionaire = false;

            bool valide = false;

            bool continuer = true;



            while(continuer){

                valide = false;

                millionaire = false;

                nbrMoisMillionaire = default;


                WriteLine(INSTRUC_DEPOT_INITIAL);

                while(!valide){
                    valide = double.TryParse(ReadLine(), out depotInitial) && depotInitial > 0;
                    if(!valide){
                        WriteLine("La valeur entrée doit être un nombre suppérieur à zéro");
                    }
                }

                depotInitialFormat = depotInitial.ToString("C");
                depotInitialFormat += ("\n");
                WriteLine(depotInitialFormat);
                

                valide = false;

                WriteLine(INSTRUC_INTERET_ANNUEL);

                while(!valide){
                    valide = double.TryParse(ReadLine(), out tauxInteretAnnuel) && tauxInteretAnnuel > 0 && tauxInteretAnnuel < 100;
                    if(!valide){
                        WriteLine("La valeur doit être un nombre situé entre 0 & 100");
                    }
                }

                tauxInteretFormat = tauxInteretAnnuel.ToString();
                tauxInteretFormat += ("%\n");
                WriteLine(tauxInteretFormat);


                valide = false;

                WriteLine(INSTRUC_DEPOT_MENSUEL);

                while(!valide){
                    valide = double.TryParse(ReadLine(), out depotMensuel) && depotMensuel > 0;
                    if(!valide){
                        WriteLine("Les dépots mensuels doivent être un nombre plus grand que zéro");
                    }
                }

                depotMensuelFormat = depotMensuel.ToString("C");
                depotMensuelFormat += ("\n");
                WriteLine(depotMensuelFormat);


                montantEconomie = depotInitial;

                while(!millionaire){
                    nbrMoisMillionaire ++;
                    montantEconomie += depotMensuel;
                    montantEconomie = montantEconomie * (1+(tauxInteretAnnuel/12/100));
                    millionaire = montantEconomie >= milion;
                }


                montantEconomieFormat = montantEconomie.ToString("C");


                investissementTotalFormat = (depotMensuel * nbrMoisMillionaire + depotInitial).ToString("C");


                interetTotal = default;
                interetTotal = (montantEconomie - depotInitial - (depotMensuel * nbrMoisMillionaire));
                interetTotalFormat = interetTotal.ToString("C");


                anneeMillionaire = Math.Floor(nbrMoisMillionaire / 12);
                moisExtraMill = nbrMoisMillionaire % 12; 



                WriteLine("\n Depot Initial               : {0} Nombre de mois millionaire  : {1} \n Total de l'investissement   : {2} \n Économies total à la fin    : {3} \n Interets total gagnés       : {4}\n\n",
                depotInitialFormat, nbrMoisMillionaire, investissementTotalFormat, montantEconomieFormat, interetTotalFormat );

                WriteLine($"Donc, il vous faudra {anneeMillionaire} années & {moisExtraMill} mois pour devenir millionaire, merde à vous !");

               
                WriteLine("\n\nVoulez vous continuer ? (O) ou (o) pour oui, (N) ou (n) pour non, NON par défault");
                ouiOuNon = ReadLine();
                continuer = ouiOuNon == "O" || ouiOuNon == "o";

            }
        }
    }
}
