﻿using System.Threading.Tasks;

namespace Motiv.Interfaces
{
    public interface IBalanceService
    {
        int Balance { get; }
        Task Init();
        void SubtractBalance(int points);
        void AddBalance(int points);
        Task Save();
    }
}
