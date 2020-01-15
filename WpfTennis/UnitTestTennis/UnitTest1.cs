using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace UnitTestTennis
{
    [TestClass]
    public class UnitTest1
    {
        Membre test = new Membre("alek", "henri", "m", "adresse", "ville", Convert.ToDateTime("16/12/1995"), "0656987456", null, 500,0);

        [TestMethod]

        //1
        public void TestMethod1() 
        {

            test.Ajouter_Victore_Simple();//on augmente son nombre de victoire donc de point
            test.Calcul_points(); // on actualise son nb de points
            Assert.AreEqual(test.NbPointGagne, 2); // on gagne 2 point  si on gagne un match simple donc on test legalite

        }

        //2
        public void Essai_Paiement_Cotisation() 
        {
            Assert.AreEqual(test.Essai_Paiement_Cotisation(), true);// on lui a mis l'argent necessaire pour payer la cotisation donc la methode devrait return true
        }

        //3
        public void Equals()
        {
            Membre test2 = test;
            Assert.AreEqual(test.Equals(test2), true);
        }

        



    }
}
