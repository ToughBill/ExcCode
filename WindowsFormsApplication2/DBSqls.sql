CREATE TABLE "BP" (
  "ID" int PRIMARY KEY,
  "Code" nvarchar(200) NOT NULL,
  "Name" nvarchar(400),
  "Country" nvarchar(50) NOT NULL,
  "Site" nvarchar(255),
  "Email" nvarchar(200),
  "ctPeson" nvarchar(40),
  "Phone" nvarchar(20),
  "Level" int NOT NULL,
  "Remark" nvarchar(max),
  "Type" int NOT NULL
);

CREATE TABLE "BPSearchPlan" (
  "ID" int PRIMARY KEY,
  "SDate" datetime,
  "EDate" datetime,
  "TargMkt" int NOT NULL,
  "Status" int NOT NULL,
  "Category" int NOT NULL,
  "SerPlantf" int,
  "KeyWord" nvarchar(1000),
  "KWLst" int,
  "Comment" nvarchar(max)
);

CREATE TABLE "Country" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(50) NOT NULL,
  "Alias" nvarchar(50) NOT NULL,
  "Capital" nvarchar(50)
);

CREATE TABLE "Category" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(50) NOT NULL,
  "Desc" nvarchar(200)
);

CREATE TABLE "KeyWord" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(20) NOT NULL,
);

CREATE TABLE "KWLIST" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(20) NOT NULL,
  "Desc" nvarchar(100)
);

CREATE TABLE "KELDetail" (
  "ID" int PRIMARY KEY,
  "KWLId" int NOT NULL,
  "KeyWord" int NOT NULL,
  "Level" int NOT NULL
);

CREATE TABLE "Market" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(50) NOT NULL,
  "Desc" nvarchar(200) NOT NULL
);

CREATE TABLE "MktDetail" (
  "ID" int PRIMARY KEY,
  "MktId" int NOT NULL,
  "CotryId" int NOT NULL
);

CREATE TABLE "Product" (
  "ID" int PRIMARY KEY,
  "Code" nvarchar(50) NOT NULL,
  "Name" nvarchar(100),
  "FName" nvarchar(100),
  "Category" int NOT NULL,
  "Refundrate" nvarchar(100) NOT NULL,
  "Remark" nvarchar(max),
  "Length" nvarchar(20),
  "Width" nvarchar(20),
  "Height" nvarchar(20),
  "Weight" nvarchar(20),
  "Texture" nvarchar(20)
);

CREATE TABLE "ProductSearchPlan" (
  "ID" int PRIMARY KEY,
  "SDate" datetime,
  "EDate" datetime,
  "Product" nvarchar(50) NOT NULL,
  "Status" int NOT NULL,
  "SerPlantf" int,
  "KeyWord" nvarchar(1000),
  "KWLst" int,
  "Comment" nvarchar(max)
);

CREATE TABLE "PSHistory" (
  "ID" int PRIMARY KEY,
  "PSPId" int NOT NULL,
  "Product" nvarchar(50) NOT NULL,
  "Link" nvarchar(255),
  "Plantf" int,
  "KeyWord" nvarchar(1000),
  "KWLst" int
);

CREATE TABLE "SearchPlantf" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(100) NOT NULL,
  "Desc" nvarchar(1000),
  "Type" nvarchar(100)
);

CREATE TABLE "Status" (
  "ID" int PRIMARY KEY,
  "Name" nvarchar(20) NOT NULL,
  "Desc" nvarchar(100)
);

CREATE TABLE "BPSearchHistory" (
  "ID" int PRIMARY KEY,
  "CSPId" int NOT NULL,
  "BP" nvarchar(200) NOT NULL,
  "Link" nvarchar(255),
  "Plantf" int,
  "KeyWord" nvarchar(1000),
  "KWLst" int
);