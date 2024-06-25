using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace drugSystemBlazor;
public class DSDBcontext : DbContext
{
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public string DBpath { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={this.DBpath}"); //设置使用SQLite

    }

    public DSDBcontext()
    {
        string path = Path.Join(Environment.CurrentDirectory, "Drug.db");
        this.DBpath = path; //设置数据库路径
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drug>().HasIndex(m => m.Name).HasDatabaseName("DrugName"); //为Drug表Name属性添加索引
        modelBuilder.Entity<Prescription>().HasIndex(p => p.PatientName).HasDatabaseName("PatientNameIndex"); //Prescription表PatientName添加索引
    }

}
public class Drug 
{
    [Key]
    public int ID { get; set; } // 药品ID
    [Required]
    public string Name { get; set; } //药品名称
    [Required]
    public float Price { get; set; } //药品单价
    [Required]
    public int Quantity { get; set; } //药品库存数量
}

public class Prescription
{
    [Key]
    public int ID { get; set; } //处方单ID
    [Required]
    public string PatientName { get; set; } //处方病人姓名
    [Required]
    public List<PrescriptionDrugs> Drugs { get; set; } //处方药品详单

    [Required]
    public bool IsPatientTakes { get; set; } //病人是否拿药

}

public class PrescriptionDrugs
{
    [Key]
    public int ID { get; set; } //无意义,用于作为主键
    [Required]
    public int DrugID { get; set; } //药品ID
    [Required]
    [ForeignKey("DrugID")]
    public Drug Drug { get; set; } //药品详情
    [Required]
    public int Quantity { get; set; } //需要拿取的这个药品的数量

}