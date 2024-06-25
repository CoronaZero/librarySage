# 期末课程设计:医院药品管理系统

### 技术栈选择:
- ASP.Net:Blazor前后端不分离,无需编写JavaScript,可以让我专注于页面的逻辑
- SQLite:轻量级数据库,无需额外安装数据库程序
- EF core:选用的ORM框架,无需手动编写SQL语句,增强程序安全性,便于开发

### 目前的BUG:
1. 药品管理-添加药品模块,添加药品后,上方的列表会出现空白项,需要刷新页面才会正常显示
2. 处方单添加-添加处方单药品-总价计算 医生在添加药品后,总价不会跟着变化,为此额外增加了一个计算用的按钮
3. 处方单查询-查找到的处方单模块,总价需要手动点击显示详情才会正常显示
