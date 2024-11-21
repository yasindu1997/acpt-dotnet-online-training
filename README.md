# create migrations
dotnet ef migrations add MigrationFileName

# update db using creted migration
dotnet ef database update

# view all executed migrations
dotnet ef migrations list

# roll back a migration
dotnet ef database update PreviousMigrationFileName

