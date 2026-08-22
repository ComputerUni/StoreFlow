# 🏪 StoreFlow - Mağaza Yönetim Sistemi


Moderni bir **ASP.NET Core 9.0 Razor Pages** uygulaması ile inşa edilmiş, tam işlevli bir **mağaza ve ürün yönetim sistemi**. Entity Framework Core, LINQ sorguları ve SQL Server veritabanı entegrasyonu kullanılarak geliştirilmiştir.

---

## 📋 Proje Özellikleri

### 🎯 Ana Özellikler

- **📦 Ürün Yönetimi** - Ürün ekleme, silme, güncelleme ve kategorilendirme
- **👥 Müşteri Yönetimi** - Müşteri bilgileri, balans ve şehir bazlı raporlama
- **📊 Sipariş Yönetimi** - Sipariş takibi, durum yönetimi ve arama işlevleri
- **🏷️ Kategori Yönetimi** - Ürün kategorilerinin düzenlenmesi
- **📝 Aktivite Takibi** - Sistem aktivitelerinin kaydedilmesi ve görüntülenmesi
- **✅ Yapılacak İşler** - Todo listesi ile görev yönetimi
- **💬 Mesaj Sistemi** - Kullanıcı iletişimi
- **📈 Dashboard & Raporlama** - İstatistiksel görsellendirmeler ve grafikler
- **🎨 Modern UI** - Melody Bootstrap Admin Dashboard Template

### 🔧 Teknoloji Stack

| Teknoloji | Versiyon | Açıklama |
|-----------|---------|----------|
| **.NET** | 9.0 | Microsoft .NET framework |
| **Entity Framework Core** | 9.0.19 | ORM ve veri erişim katmanı |
| **SQL Server** | 2019+ | İlişkisel veritabanı |
| **Bootstrap** | 5 | Responsive UI framework |
| **jQuery** | 3 | Frontend interaktivitesi |
| **X.PagedList** | 10.5.9 | Sayfalama ve listeleme |

---

## 🗄️ Veritabanı Şeması

### Tablolar

```
📊 Veritabanı: StoreFlowDb

├── Categories
│   └── Ürün kategorileri
│
├── Products
│   ├── Ürün bilgileri
│   └── → FK: Category
│
├── Customers
│   ├── Müşteri bilgileri
│   └── Şehir, balans, iletişim
│
├── Orders
│   ├── Sipariş bilgileri
│   ├── Sipariş durumu (Beklemede, Tamamlandı, İptal)
│   └── → FK: Customer, Product
│
├── Activities
│   └── Sistem aktivite logları
│
├── Todos
│   ├── Yapılacak işler
│   ├── Öncelik (Düşük, Orta, Yüksek)
│   └── Durum (Tamamlandı, Tamamlanmadı)
│
└── Messages
	└── Mesaj sistemi
```

---

## 🚀 Başlangıç

### Kurulum Adımları

#### 1. Depoyu Klonlayın

```bash
git clone https://github.com/ComputerUni/StoreFlow.git
cd StoreFlow
```

#### 2. Veritabanı Bağlantı Dizesini Yapılandırın

`StoreFlow/Context/StoreContext.cs` dosyasında bağlantı dizesini kendi SQL Server örneğinize göre güncelleyin:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
	optionsBuilder.UseSqlServer("Server=SUNUCU_ADI\\SQLEXPRESS;Database=StoreFlowDb;Integrated Security=True;TrustServerCertificate=True;");
}
```

#### 3. Veritabanı Migrasyonlarını Uygulayın

Visual Studio Package Manager Console'da:

```powershell
Update-Database
```

veya .NET CLI ile:

```bash
dotnet ef database update
```

#### 4. Uygulamayı Çalıştırın

Visual Studio'da **F5** tuşuna basın veya terminal'de:

```bash
dotnet run
```

Uygulama şu adrestte açılacaktır: `https://localhost:5001` veya `https://localhost:7000`

---

## 📁 Proje Yapısı

```
StoreFlow/
├── Context/
│   └── StoreContext.cs              # Entity Framework DbContext
│
├── Controllers/
│   ├── ProductController.cs          # Ürün yönetimi
│   ├── CustomerController.cs         # Müşteri yönetimi
│   ├── OrderController.cs            # Sipariş yönetimi
│   ├── CategoryController.cs         # Kategori yönetimi
│   ├── ActivityController.cs         # Aktivite takibi
│   ├── TodoController.cs             # Yapılacak işler
│   ├── MessageController.cs          # Mesaj sistemi
│   ├── DashboardController.cs        # Dashboard
│   └── HomeController.cs             # Ana sayfa
│
├── Entities/
│   ├── Product.cs                   # Ürün entity'si
│   ├── Customer.cs                  # Müşteri entity'si
│   ├── Order.cs                     # Sipariş entity'si
│   ├── Category.cs                  # Kategori entity'si
│   ├── Activity.cs                  # Aktivite entity'si
│   ├── Todo.cs                      # Todo entity'si
│   └── Message.cs                   # Mesaj entity'si
│
├── Models/
│   ├── ProductWithCategoryViewModel.cs
│   ├── CustomerIndexViewModel.cs
│   ├── OrderStatusChartViewModel.cs
│   ├── TodoStatusChartViewModel.cs
│   ├── CustomerCityChartViewModel.cs
│   └── Diğer ViewModels...
│
├── Views/
│   ├── Dashboard/                   # Dashboard sayfaları
│   ├── Product/                     # Ürün yönetimi sayfaları
│   ├── Customer/                    # Müşteri yönetimi sayfaları
│   ├── Order/                       # Sipariş yönetimi sayfaları
│   ├── Category/                    # Kategori yönetimi sayfaları
│   ├── Activity/                    # Aktivite sayfaları
│   ├── Todo/                        # Todo sayfaları
│   ├── Message/                     # Mesaj sayfaları
│   ├── Shared/                      # Layout ve shared components
│   └── _Layout.cshtml               # Master layout
│
├── ViewComponents/
│   ├── DashboardChartsViewComponents/
│   ├── LayoutViewComponents/
│   ├── RightSidebarComponents/
│   ├── StatisticViewComponents/
│   └── Diğer componentler...
│
├── Migrations/
│   └── [EF Core database migrations]
│
├── wwwroot/
│   ├── css/                         # Stil dosyaları
│   ├── js/                          # JavaScript dosyaları
│   ├── lib/                         # Kütüphaneler (Bootstrap, jQuery vb.)
│   └── Melody-Premium-Bootstrap-Admin-Dashboard-Template/
│       └── Admin dashboard şablonu
│
├── Properties/
│   └── launchSettings.json
│
├── appsettings.json                 # Uygulamız ayarları
├── appsettings.Development.json
├── Program.cs                       # Uygulama başlangıç noktası
├── StoreFlow.csproj                 # Proje dosyası
└── StoreFlow.slnx                   # Solution dosyası
```

---

## 🎥 Ekran Görüntüleri

### 1. Dashboard Ana Sayfa
![Dashboard](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/1.png)

### 2. Ürün Yönetimi
![Ürün Listesi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/2.png)

### 3. Ürün Ekleme/Düzenleme Formu
![Ürün Ekleme](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/3.png)

### 4. Kategori Yönetimi
![Kategori Listesi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/4.png)

### 5. Müşteri Yönetimi - Şehir Analizi
![Müşteri Şehir Dağılımı](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/5.png)

### 6. Müşteri Detayları
![Müşteri Detayları](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/6.png)

### 7. Müşteri Listesi
![Müşteri Listesi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/7.png)

### 8. Sipariş Yönetimi - Status Filtrelemeleri
![Sipariş Listesi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/8.png)

### 9. Sipariş Oluşturma
![Sipariş Oluşturma](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/9.png)

### 10. Aktivite Takibi
![Aktivite Takvimi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/10.png)

### 11. Aktivite Listesi
![Aktivite Listesi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/11.png)

### 12. Yapılacak İşler - Todo
![Todo Listesi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/12.png)

### 13. Mesaj Sistemi - Kullanıcı İletişimi
![Mesaj Sistemi](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/13.png)

### 14. Düzenleme ve Yönetim Arayüzü
![Yönetim Paneli](https://github.com/ComputerUni/StoreFlow/raw/main/screenshots/14.png)

---

## 💻 Kullanılacak LINQ Sorguları

Proje kapsamında Advanced LINQ tekniklerinin kullanıldığı alanlar:

### Veri Sorgulama Örnekleri

- **Select & SelectMany** - Ürünleri kategorileriyle birlikte getirme
- **Where & Filtering** - Durum bazlı sipariş filtreleme
- **GroupBy & Aggregation** - Müşteri sayısı şehir bazında
- **Join & Relationships** - Ürün-Kategori, Sipariş-Müşteri ilişkileri
- **OrderBy & ThenBy** - Sıralama işlemlerine
- **Skip & Take** - Sayfalama işlemleri
- **Distinct & Union** - Tekrar eden verilerin temizlenmesi
- **Any & All** - Kontrol sorguları
- **Average & Sum** - İstatistik hesaplamaları
- **DefaultIfEmpty** - Boş veri setleri için varsayılan değerler
- **Intersect & Except** - Küme operasyonları
- **Chunk & Aggregate** - Veri ayırma ve birleştirme

---


## 🛠️ API Endpoints Örneği

### Ürün Yönetimi
- `GET  /Product/ProductList` - Tüm ürünleri listele
- `GET  /Product/CreateProduct` - Ürün ekleme formu
- `POST /Product/CreateProduct` - Ürün ekle
- `GET  /Product/UpdateProduct/{id}` - Ürün düzenleme formu
- `POST /Product/UpdateProduct` - Ürün güncelle
- `GET  /Product/DeleteProduct/{id}` - Ürün sil

### Müşteri Yönetimi
- `GET  /Customer/CustomerListOrderByCustomerName` - Müşteri listesi
- `GET  /Customer/CustomerCityList` - Şehire göre müşteri listesi
- `GET  /Customer/CustomersByCityCount` - Şehir bazında müşteri sayısı
- `GET  /Customer/ParallelCustomers` - Parallel LINQ örneği

### Sipariş Yönetimi
- `GET  /Order/OrderListByStatus` - Durum bazında siparişler
- `GET  /Order/CreateOrder` - Sipariş oluşturma
- `GET  /Order/OrderListSearch` - Sipariş arama

### Dashboard
- `GET  /Dashboard/Index` - Ana dashboard
- `GET  /Dashboard/Statistic` - İstatistik bilgileri

---

## 📝 Kod Örnekleri

### Entity Tanımı (Ürün)

```csharp
public class Product
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }
	public decimal ProductPrice { get; set; }
	public int ProductStock { get; set; }
	public int CategoryId { get; set; }
	public Category Category { get; set; }
	public string ProductImage { get; set; }
}
```

### LINQ Sorgusu - Kategorileriyle Ürünleri Getirme

```csharp
var products = context.Products
	.Include(p => p.Category)
	.Select(p => new ProductWithCategoryViewModel
	{
		ProductId = p.ProductId,
		ProductName = p.ProductName,
		ProductPrice = p.ProductPrice,
		CategoryName = p.Category.CategoryName
	})
	.ToList();
```

### Müşteri Şehir Analizi

```csharp
var cityStats = context.Customers
	.GroupBy(c => c.CustomerCity)
	.Select(g => new CustomerCityChartViewModel
	{
		City = g.Key,
		Count = g.Count(),
		TotalBalance = g.Sum(c => c.CustomerBalance)
	})
	.OrderByDescending(x => x.Count)
	.ToList();
```

---


## 🎓 Öğrenme Kaynakları

Bu proje aşağıdaki konuları öğrenmek için harika bir kaynaktır:

- ✅ ASP.NET Core 9.0 ve Razor Pages mimarisi
- ✅ Entity Framework Core - ORM ve DbContext
- ✅ LINQ - Gelişmiş sorgu teknikleri
- ✅ SQL Server veri tabanı tasarımı
- ✅ Repository Pattern ve veri erişim katmanları
- ✅ MVC/MVP tasarım desenleri
- ✅ Bootstrap 5 ile responsive UI tasarımı
- ✅ View Components ve kısmi sayfalar
- ✅ Veri görselleştirme (Chart.js, Morris.js)
- ✅ Veritabanı migrasyonları ve versionlama

---

<div align="center">

**⭐ Bu projeyi yararlı bulduysanız, lütfen star vermeyi unutmayın! ⭐**

Made with ❤️ by [ComputerUni](https://github.com/ComputerUni)

</div>
