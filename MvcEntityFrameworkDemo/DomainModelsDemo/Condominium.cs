﻿using System.Collections.Generic;

namespace DomainModelsDemo
{
    public class Condominium
    {
        public int Id { get; set; }

        public long SubsidiaryId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }
        public List<Zone> Zones { get; set; }
    }
}