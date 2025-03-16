# CASE-1: Kütüphane Otomasyon Sistemi

Bu proje, bir kütüphane yönetim sisteminin RESTful API'sini içermektedir. Sistem, kitapların ve üyelerin yönetimini sağlar, ödünç alma ve iade işlemlerini destekler.

## Swagger UI 

<p align="center">
  <img src="swg.png" alt="Swagger UI Arayüzü" width="800">
</p>

dotnet watch
http://localhost:5000/index.html


### 1. Kitap Ödünç Alma İşlevi

- Endpoint: `POST /api/Members/{memberNumber}/borrow/{isbn}`
- Özellikler:
  * Üye kontrolü
  * Kitap müsaitlik kontrolü
  * Otomatik durum güncelleme
  * İşlem kaydı tutma

### 2. Kitap İade İşlevi

- Endpoint: `POST /api/Members/{memberNumber}/return/{isbn}`
- Özellikler:
  * Ödünç alma kaydı kontrolü
  * Otomatik durum güncelleme
  * İade tarihi kaydı
  * Geçmiş işlem kaydı

### 3. Kitap Durumu Güncelleme

- Endpoint: `PUT /api/Books/{isbn}/status`
- Desteklenen Durumlar:
  * Available (Ödünç alınabilir)
  * Borrowed (Ödünçte)
  * Unavailable (Mevcut değil)
- Özellikler:
  * Durum geçiş kontrolü
  * Otomatik güncelleme
  * İşlem doğrulama

### 4. Üye Kitap Görüntüleme

- Endpoint: `GET /api/Members/{memberNumber}/borrowed-books`
- Özellikler:
  * Aktif ödünç kayıtları
  * Kitap detayları
  * Ödünç alma/iade tarihleri
  * Durum bilgisi

### 5. Kütüphane Durumu Görüntüleme
✓ Karşılandı
- Endpoints:
  * `GET /api/Books/available` (Mevcut kitaplar)
  * `GET /api/Books/borrowed` (Ödünç alınan kitaplar)
  * `GET /api/Members` (Üye listesi)
  * `GET /api/Books/byType` (Kitap türüne göre liste)
  * `GET /api/Books/byAuthor` (Yazara göre liste)
- Özellikler:
  * Detaylı filtreleme
  * Anlık durum bilgisi
  * İstatistiksel veriler

### Ek Geliştirmeler
Temel gereksinimlerin ötesinde eklenen özellikler:
1. **Kitap Türü Yönetimi**
   - Farklı kitap türleri için özel alanlar
   - Dinamik tür ekleme altyapısı
   - Tür bazlı filtreleme

2. **Gelişmiş Üye Yönetimi**
   - Detaylı üye profili
   - Ödünç alma geçmişi
   - İşlem limitleri

3. **Sistem Güvenliği**
   - Veri doğrulama
   - Hata yönetimi
   - İşlem logları

4. **Raporlama**
   - Kitap durumu raporları
   - Üye aktivite raporları
   - Sistem kullanım istatistikleri


