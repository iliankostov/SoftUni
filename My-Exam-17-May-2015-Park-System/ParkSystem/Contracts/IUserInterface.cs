﻿namespace ParkSystem
{
    public interface IUserInterface
    {
        string ReadLine(); 

        void WriteLine(string format, params string[] args);
    }
}