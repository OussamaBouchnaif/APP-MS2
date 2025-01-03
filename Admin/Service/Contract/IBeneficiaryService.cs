﻿using Admin.ViewModel;
using MS2Api.Model;
using System.Linq.Expressions;

namespace Admin.Service.Contract
{
    public interface IBeneficiaryService
    {
        IEnumerable<Benificier> GetAllBeneficiaries();

        Benificier GetBenificierById(int id);

        Benificier FindBenificierByExpression(Expression<Func<Benificier, bool>> predicate);

        IEnumerable<Benificier> FindManyBeneficiariesByExpression(Expression<Func<Benificier, bool>> predicate);

        void AddBenificier(BenificierVM benificierVM);

        void UpdateBenificier(BenificierVM benificierVM, Benificier benificier);

        bool DeleteBenificier(Benificier benificier);

        public Task<StatistiquesData> GetStatistiquesAsync();

        void SaveChanges();

        string GenerateUniqueSuffix();

        Benificier FindByCodeUnique(string codeUnique);
    }
}