namespace JohannMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            //Pay As You Go
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE Id = 1");
            //Monthly
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
            //Quarterly
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            //Annual
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
