﻿namespace CardBattle.Domain.Models
{
    public interface IPlayersRepository
    {
        void Add(Players players);

        Players Get(Players players);

        Players GetPlayerInformation(Players players);
        
    }
}
