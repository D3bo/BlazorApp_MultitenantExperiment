﻿namespace BlazorApp2.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string TenantId { get; set; } = null!;
    }
}
