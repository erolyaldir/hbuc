## Hepsiburada Search & Navigation Data Team Assignment
Case de istenilen bütün işlemler uygulanmıştır.
3 gün süre yetmediği için oluşturulan docker image üzerinden docker-compose ile çalıştırma ve Unit testler eklenememiştir.

-Uygulamanın çalıştırılması için StreamReader.Infrastruce altındaki migrationslar "dotnet ef database update" ile yüklenmelidir.Eğer tool yok ise "dotnet tool install" ile yüklene bilir.
-Uygulamada sizin gönderdiğiniz docker-compose a Redis ekledim. "docker-compose up -d" ile çalıştırılması gerekiyor.

Genel
	-Uygulamada HBUC.Framework içerisinde bütün ortak işlemleri topladım.
	-Generic Repository ile her uygulamada tek repository pattern ile geliştirme yaptım.
	-Bütün registirationlar ilgili uygulamanın Infrastruce'ı içerisinde ki RegisterServiceExtensions de yapılmıştır.Bu sayede daha app.config okunabilir kalmıştır.
	-Tek db kullanımı microservis için doğru değil ama ayrı schema ile miniServis mantığında dbleri fiziki olmasabile ayrı kullandım.
	

ViewProducer
	-Bulk ve tek olarak verilen productViewları Kafka produce ediyor.


StreamReader
	-Kafkadan aldığı verileri Db ye yazıyor.
	-Burada tektek yazmak yerine bulk insert yapılabilir.
	-Migrationlar bu projede bulunuyor
ELTProces
	-Uygula cron job ile 5dkda bir verileri Redise yazıyor.Süre appsettingden değiştirilebilir.
RecommendationAPI
	