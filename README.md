# KATACHI MVC - 健身訓練日誌

## 專案介紹

KATACHI MVC 是健身訓練日誌的後端整合版本，以 ASP.NET Core MVC 架構連接 MS SQL Server 資料庫，提供完整的使用者登入、訓練紀錄讀寫、統計分析與肌群分布等功能。

## 功能特色

- **帳號系統**：使用者註冊 / 登入 / 登出，Cookie 驗證（7 天有效期）
- **訓練日誌**：月曆視圖、每日訓練詳情、新增 / 刪除訓練項目、組數勾選
- **訓練統計**：折線圖雙月 / 年對比、動作歷史 PR / RM、器材分組摘要
- **肌群分析**：SVG 人體熱力圖、訓練佔比圖表、目標達成率、本月建議
- **目標設定**：各肌群每月目標組數步進調整，即時寫入資料庫

## 專案結構

```
katachi/
├── Controllers/
│   ├── HomeController.cs                   # 導向 TrainingLog
│   ├── AccountController.cs                # 登入 / 註冊 / 登出
│   ├── TrainingLogController.cs            # 主控制器（Index）
│   ├── TrainingLogController.CRUD.cs       # 訓練紀錄 CRUD
│   ├── TrainingLogController.Stats.cs      # 統計 API
│   ├── TrainingLogController.MuscleAnalysis.cs  # 肌群分析 API
│   └── TrainingLogController.Goals.cs      # 目標設定 API
├── Helpers/
│   └── DbHelper.cs        # ADO.NET 資料庫連線封裝
├── Models/
│   ├── Entities/          # EF Core 實體（User、Exercise、MuscleGroup 等）
│   ├── Account/           # 登入 / 註冊 ViewModel
│   ├── Stats/             # 統計資料模型
│   ├── Records/           # PR / RM 紀錄模型
│   ├── Training/          # 訓練日誌 ViewModel
│   └── KatachiDbContext.cs
├── Views/
│   ├── Account/index.cshtml
│   ├── Shared/_Layout.cshtml
│   └── TrainingLog/Index.cshtml
└── wwwroot/
    ├── css/               # 樣式表
    └── js/                # 前端邏輯
```

## 技術堆疊

- ASP.NET Core MVC (.NET 10)
- MS SQL Server + ADO.NET（複雜查詢）+ Entity Framework Core（實體操作）
- C#
- HTML5 / CSS3 / JavaScript (ES6)
- Chart.js 4.4.1
- Google Fonts

## 安裝與使用

### 前置需求

- .NET 10 SDK
- MS SQL Server（本機或遠端）

### 步驟

1. Clone 專案：

```bash
git clone https://github.com/JoeCode08888/fitness-training-log-mvc.git
cd fitness-training-log-mvc/katachi
```

2. 建立資料庫，SQL 腳本請至前端靜態版專案取得：
[fitness-training-log](https://github.com/JoeCode08888/fitness-training-log) → `sql/`

```
01_create_tables.sql    # 建立資料表
02_seed_static.sql      # 匯入靜態資料（動作、肌群、器材）
03_seed_training.sql    # 匯入訓練紀錄假資料
```

3. 設定連線字串（`appsettings.json`）：

```json
"ConnectionStrings": {
  "KatachiDb": "Server=.;Database=katachi;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

4. 執行專案：

```bash
dotnet run
```

5. 開啟瀏覽器：`https://localhost:5001`

## 資料庫 Schema

| 資料表 | 說明 |
|---|---|
| `users` | 使用者資料（帳號、密碼雜湊、個人資料） |
| `exercises` | 動作字典 |
| `muscle_groups` | 7 大肌群 |
| `muscles` | 細部肌肉部位 |
| `equipment` | 器材類型 |
| `exercise_equipment` | 動作 ↔ 器材對應 |
| `exercise_group_pct` | 動作 ↔ 肌群佔比 |
| `user_goals` | 每月肌群目標組數 |
| `training_sessions` | 訓練日 |
| `training_items` | 單日訓練項目 |
| `training_sets` | 單組完成狀態 |

## License

MIT License

## About

KATACHI MVC 健身訓練日誌由 JoeCode08888 開發，為前端靜態版本的後端整合實作。
