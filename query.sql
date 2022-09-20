CREATE TABLE karyawan(
	id INT PRIMARY KEY,
	username VARCHAR(20) UNIQUE NOT NULL,
	password VARCHAR(50) NOT NULL,
	email VARCHAR(50) UNIQUE NOT NULL,
	jabatan VARCHAR(50) NOT NULL,
);

CREATE TABLE surat_masuk(
	id INT PRIMARY KEY,
	tgl_masuk DATE NOT NULL,
	no_surat VARCHAR(50) UNIQUE NOT NULL,
	kode_surat VARCHAR(50) NOT NULL,
	asal_surat VARCHAR(255) NOT NULL,
	perihal TEXT NOT NULL,
	lampiran VARCHAR(255) NOT NULL,
	keterangan VARCHAR(255) NOT NULL,
	--pengolah surat--
	karyawan_id INT, 
	FOREIGN KEY (karyawan_id) REFERENCES karyawan(id)
);

CREATE TABLE disposisi(
	id INT PRIMARY KEY,
	--tujuan disposisi--
	karyawan_id INT FOREIGN KEY (karyawan_id) REFERENCES karyawan(id),
	surat_masuk_id INT FOREIGN KEY (surat_masuk_id) REFERENCES surat_masuk(id),
	status_disposisi VARCHAR(50) NOT NULL,
	isi VARCHAR(255) NOT NULL,
	kepentingan VARCHAR(255) NOT NULL,
	catatan VARCHAR(255) NOT NULL,
);

CREATE TABLE surat_keluar(
	id INT PRIMARY KEY,
	tgl_terbit DATE NOT NULL,
	no_surat VARCHAR(50) UNIQUE NOT NULL,
	kode_surat VARCHAR(50) NOT NULL,
	tujuan_surat VARCHAR(255) NOT NULL,
	perihal TEXT NOT NULL,
	lampiran VARCHAR(255) NOT NULL,
	keterangan VARCHAR(255) NOT NULL,
	--pengolah surat--
	karyawan_id INT, 
	FOREIGN KEY (karyawan_id) REFERENCES karyawan(id),
	surat_masuk_id INT FOREIGN KEY (surat_masuk_id) REFERENCES surat_masuk(id)
);