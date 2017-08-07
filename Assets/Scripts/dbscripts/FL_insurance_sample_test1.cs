using SQLite4Unity3d;
using System;

public class FL_insurance_sample_test1
{

	[PrimaryKey, AutoIncrement]
    public int policyID { get; set; }

    public string statecode { get; set; }
    public string county { get; set; }
    public float eq_site_limit { get; set; }
    public float hu_site_limit { get; set; }
    public float fl_site_limit { get; set; }
    public float fr_site_limit { get; set; }
    public float tiv_2011 { get; set; }
    public float tiv_2012 { get; set; }
    public float eq_site_deductible { get; set; }
    public float hu_site_deductible { get; set; }
    public float fl_site_deductible { get; set; }
    public float fr_site_deductible { get; set; }
    public float point_latitude { get; set; }
    public float point_longitude { get; set; }
    public string line { get; set; }
    public string construction { get; set; }
    public int point_granularity { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Valid_Until { get; set; }

	public override string ToString ()
	{
		return string.Format ("[Row: policyID={0}, statecode={1},  county={2}, point_granularity={3}]", policyID, statecode, county, point_granularity);
	}
}
