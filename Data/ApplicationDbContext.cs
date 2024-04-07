﻿using AssignmentApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace AssignmentApp.Data
{
	public class ApplicationDbContext: IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{

		}
		public DbSet<StudentEntity> Student { get; set; }

		public DbSet<ApplicationUser> AppUser { get; set; }
	}
	
}