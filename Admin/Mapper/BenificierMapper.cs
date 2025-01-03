﻿using Admin.Mapper.Contract;
using Admin.ViewModel;
using MS2Api.Model;

namespace Admin.Mapper
{
    public class BenificierMapper : IBenificierMapper
    {
        public Benificier MapToBenificier(BenificierVM benificierVm)
        {
            if (benificierVm == null)
            {
                return null;
            }
            return new Benificier
            {
                Nom = benificierVm.Nom,
                Prenom = benificierVm.Prenom,
                Age = benificierVm.Age,
                Sexe = benificierVm.Sexe,
                Tele = benificierVm.Tele,
                TeleUrgent = benificierVm.TeleUrgent,
                PaysOrigin = benificierVm.PaysOrigin,
                Nationalite = benificierVm.Nationalite,
                Address = benificierVm.Address,
                Ville = benificierVm.Ville,
                TypeDetection = benificierVm.TypeDetection,
                codeUnique = benificierVm.codeUnique
            };
        }

        public Benificier UpdateBenificier(BenificierVM benificierVm, Benificier benificier)
        {
            if (benificierVm == null || benificier == null)
            {
                return null;
            }

            benificier.Nom = benificierVm.Nom;
            benificier.Prenom = benificierVm.Prenom;
            benificier.Age = benificierVm.Age;
            benificier.Sexe = benificierVm.Sexe;
            benificier.Tele = benificierVm.Tele;
            benificier.TeleUrgent = benificierVm.TeleUrgent;
            benificier.PaysOrigin = benificierVm.PaysOrigin;
            benificier.Nationalite = benificierVm.Nationalite;
            benificier.Address = benificierVm.Address;
            benificier.Ville = benificierVm.Ville;
            benificier.TypeDetection = benificierVm.TypeDetection;
            benificier.codeUnique = benificierVm.codeUnique;

            return benificier;
        }

        public BenificierVM MapToBenificierVM(Benificier benificier)
        {
            if (benificier == null)
            {
                return null;
            }
            return new BenificierVM
            {
                Nom = benificier.Nom,
                Prenom = benificier.Prenom,
                Age = benificier.Age,
                Sexe = benificier.Sexe,
                Tele = benificier.Tele,
                TeleUrgent = benificier.TeleUrgent,
                PaysOrigin = benificier.PaysOrigin,
                Nationalite = benificier.Nationalite,
                Address = benificier.Address,
                Ville = benificier.Ville,
                TypeDetection = benificier.TypeDetection,
                codeUnique = benificier.codeUnique
            };
        }
    }
}