namespace BlazorApp2.Data
{
    public class Costumer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //this is the sql query to create the table
    //CREATE TABLE [dbo].[Costumers] (
    //    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    //    [Name] NVARCHAR (MAX) NULL,
    //    PRIMARY KEY CLUSTERED ([Id] ASC)
    //);



}
