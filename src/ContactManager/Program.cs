// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ContactManager;

using ContactManager.Repository;
using ContactManager.Services;
using ContactManager.View;

/// <summary>
/// Main class where program starts.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main Functions.
    /// </summary>
    public static void Main()
    {
        ContactRepository contactRepository = new ();
        ContactController contactController = new ContactController(contactRepository);
        ConsoleOperations consoleOperations = new ConsoleOperations(contactController);

        consoleOperations.MenuInfo();
    }
}