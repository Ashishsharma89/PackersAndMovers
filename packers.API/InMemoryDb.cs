using Packer.Domain.Entities;
using System.Collections.Generic;

public static class InMemoryDb
{
    public static List<User> Users { get; set; } = new();
    public static List<MoveRequest> Moves { get; set; } = new();
} 