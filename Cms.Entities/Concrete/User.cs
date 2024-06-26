﻿using Cms.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Entities.Concrete
{
	public class User : EntityBase, IEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public City City { get; set; }
		public int CityId { get; set; }
		public string Phone { get; set; }
		public string CitizenId { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }
		public byte[] PasswordHash { get; set; }
		public string Picture { get; set; }
		public ICollection<Appointment> Appointments { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public ICollection<Article> Articles { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }
	}
}
