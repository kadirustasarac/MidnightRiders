# Midnight Riders

## İçindekiler
- [Proje Hakkında](#proje-hakkında)
- [Özellikler](#özellikler)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Kurulum](#kurulum)
- [Kullanım](#kullanım)
- [Katkıda Bulunma](#katkıda-bulunma)
- [Lisans](#lisans)

---

## Proje Hakkında
Midnight Riders, Unity kullanılarak geliştirilmiş bir runner tarzı oyundur. Oyuncular, dar bir yolda ilerlerken engellerden kaçmak ve puan toplamak için A ve D tuşlarını kullanarak sağa ve sola hareket eder. Basit ama bağımlılık yapıcı bir oynanış sunar.

Bu oyun, hızlı refleksler ve odaklanma gerektirerek oyunculara eğlenceli bir deneyim sunar.

## Özellikler
- **3 Yol Seçeneği**: Oyuncular, A ve D tuşlarıyla sağa veya sola geçerek 3 farklı yolda ilerleyebilir.
- **Engeller**: Yol boyunca çıkan engellerden kaçın.
- **Puan Toplama**: Oyuncular, ilerledikçe puan kazanır.
- **Basit Kontroller**: Sadece klavyede A ve D tuşlarını kullanarak oynanır.
- **Sonsuz Oyun**: Zorluk seviyesi zamanla artan sonsuz bir oyun.

## Kullanılan Teknolojiler
- **Unity**: Oyunun geliştirilmesi için kullanılan oyun motoru.
- **C#**: Oyun mekaniği ve sistemleri için kullanılan programlama dili.
- **Blender**: Basit 3D modelleme ve çevre tasarımı için.
- **Adobe Photoshop**: Oyun içi görseller ve dokuların oluşturulması için.

## Kurulum
Bu oyunu çalıştırmak için aşağıdaki adımları izleyin:

1. Depoyu klonlayın:
   ```bash
   git clone https://github.com/yourusername/midnight-riders.git
   cd midnight-riders
   ```

2. Unity Hub ile projeyi açın:
   - Unity Hub'ı başlatın.
   - "Add" butonuna tıklayın ve projeyi seçin.
   - Gerekli Unity sürümünü indirip projeyi başlatın.

3. Gerekli bağımlılıkları kontrol edin:
   - Projenin doğru çalışması için Unity paketi bağımlılıklarının eksiksiz olduğundan emin olun.

## Kullanım
1. Oyunu Unity Editor içinde başlatmak için `Play` tuşuna basın.
2. Oyunu derlemek için:
   - Unity menüsünden `File > Build Settings` yolunu izleyin.
   - Hedef platformu seçin (örneğin, Windows veya MacOS).
   - `Build` butonuna tıklayın ve çalıştırılabilir dosyayı oluşturun.
3. Oyuna başlamak için derlenmiş dosyayı çalıştırın.

### Oynanış İpuçları
- **Hızlı Refleksler**: Engellerden kaçınmak için doğru zamanda hareket edin.
- **Yol Seçimi**: Hangi yolda kalacağınıza hızlıca karar verin.
- **Puanınızı Artırın**: Daha uzun süre hayatta kalarak yüksek puanlara ulaşın.

## Katkıda Bulunma
Projeye katkıda bulunmak istiyorsanız şu adımları izleyebilirsiniz:

1. Depoyu fork edin.
2. Yeni bir özellik dalı oluşturun:
   ```bash
   git checkout -b ozellik-adi
   ```
3. Değişikliklerinizi kaydedin:
   ```bash
   git commit -m "Yeni bir özellik ekle"
   ```
4. Dalınızı ittirin:
   ```bash
   git push origin ozellik-adi
   ```
5. Bir pull request oluşturun.

## Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.

---

**Not**: Oynanışı optimize etmek için Unity'nin Time.deltaTime ve Rigidbody sistemlerini etkili bir şekilde kullanın.
