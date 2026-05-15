# KATACHI MVC - 健身訓練日誌

![KATACHI](https://img.shields.io/badge/KATACHI-ASP.NET_Core_MVC-3d5247)

## 專案介紹

KATACHI MVC 是健身訓練日誌的後端整合版本，以 ASP.NET Core MVC 架構連接 MS SQL Server 資料庫，提供完整的訓練紀錄讀寫、統計分析與肌群分布等功能。

## 功能特色

- **訓練日誌**：月曆視圖、每日訓練詳情、新增 / 刪除訓練項目、組數勾選
- **訓練統計**：折線圖雙月 / 年對比、動作歷史 PR、器材分組摘要
- **肌群分析**：SVG 人體熱力圖、訓練佔比圖表、目標達成率、本月建議
- **目標設定**：各肌群每月目標組數步進調整，即時寫入資料庫

## 專案結構

```
katachi/
├── Controllers/
│   ├── TrainingLogController.cs        # 主控制器（Index）
│   ├── TrainingLogController.CRUD.cs   # 訓練紀錄 CRUD
│   ├── TrainingLogController.Stats.cs  # 統計 API
│   ├── TrainingLogController.P3.cs     # 肌群分析 API
│   └── TrainingLogController.Goals.cs  # 目標設定 API
├── Helpers/
│   └── DbHelper.cs        # ADO.NET 資料庫連線封裝
├── Models/
│   ├── Records/           # PR / RM 紀錄模型
│   ├── Stats/             # 統計資料模型
│   └── Training/          # 訓練日誌 ViewModel
├── Views/
│   ├── Shared/_Layout.cshtml
│   └── TrainingLog/Index.cshtml
└── wwwroot/
    ├── css/               # 樣式表
    └── js/                # 前端邏輯
```

## 技術堆疊

- ASP.NET Core MVC (.NET 10)
- MS SQL Server + ADO.NET
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

2. 建立資料庫，依序執行 `sql/` 資料夾內的 SQL 腳本：

```
01_create_tables.sql   # 建立資料表
02_seed_static.sql     # 匯入靜態資料（動作、肌群）
03_seed_sessions.sql   # 匯入訓練紀錄假資料
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
| `exercises` | 動作字典（28 個） |
| `muscle_groups` | 7 大肌群 |
| `muscles` | 細部肌肉部位（20 個） |
| `exercise_group_pct` | 動作 ↔ 肌群佔比 |
| `users` | 使用者資料 |
| `user_goals` | 每月肌群目標組數 |
| `training_sessions` | 訓練日 |
| `training_items` | 單日訓練項目 |
| `training_sets` | 單組完成狀態 |

## License

MIT License

## About

KATACHI MVC 健身訓練日誌由 JoeCode08888 開發，為前端靜態版本的後端整合實作。
