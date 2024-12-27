using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace librarySage;
public class DSDBcontext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public string DBpath { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={this.DBpath}"); //设置使用SQLite

    }

    public DSDBcontext()
    {
        string path = Path.Join(Environment.CurrentDirectory, "Library.db");
        this.DBpath = path; //设置数据库路径
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasIndex(m => m.Name).HasDatabaseName("BookName"); //为图书表Name属性添加索引
        modelBuilder.Entity<Order>().HasIndex(p => p.CustomName).HasDatabaseName("CustomNameIndex"); //Order表CustomName添加索引
    }

}
public class Book
{
    [Key]
    public int ID { get; set; } // 图书ID
    [Required]
    public string Name { get; set; } //图书名称
    [Required]
    public float Price { get; set; } //图书单价
    [Required]
    public int Quantity { get; set; } //图书库存数量
}

public class Order
{
    [Key]
    public int ID { get; set; } //订单ID
    [Required]
    public string CustomName { get; set; } //客人姓名
    [Required]
    public List<OrderBooks> Books { get; set; } //订单图书详单

    [Required]
    public bool IsTakes { get; set; } //是否已拿书

}

public class OrderBooks
{
    [Key]
    public int ID { get; set; } //无意义,用于作为主键
    [Required]
    public int BookID { get; set; } //图书ID
    [Required]
    [ForeignKey("BookID")]
    public Book Book { get; set; } //图书详情
    [Required]
    public int Quantity { get; set; } //需要拿取的这个图书的数量

}