# Unity 擴充方法函式庫

一個專為 Unity 開發者設計的擴充方法函式庫，提供多種實用的擴充方法，協助提升開發效率、簡化程式碼撰寫，並封裝為 DLL 類別庫，方便快速整合至您的專案。

## 功能特色

此函式庫包含多個擴充方法，分為以下類別，適用於多種場景的 Unity 開發需求：

### 1. `ComponentExtensions`
提供 Unity 組件的實用擴充方法，支援組件操作與管理：
- 重新啟動行為腳本：`Restart`
- 設定啟用狀態：`SetActive`
- 判斷組件是否為空：`IsNull`
- 嘗試新增組件：`TryAddComponent`

### 2. `GameObjectExtensions`
提供 GameObject 的操作擴充方法，涵蓋建立、屬性操作、層級管理等功能：
- 獲取物件的層級索引：`GetSiblingIndex`
- 動態生成物件（支援父物件與位置設定）：`Instantiate`
- 重置本地位移、旋轉、縮放：`ResetLocal`
- 設定 Anchor 與 Offset：`SetAnchor`、`SetOffset`
- 層級管理（設定父物件、調整順序）：`SetParent`、`SetSiblingIndex`
- 設定顯示狀態：`TrySetActive`

### 3. `VisualExtensions`
提供 Unity 視覺相關類別的操作擴充方法：
- 動畫管理：`GetStateInfo`、`Wait`
- 顏色轉換：`ToHex`、`ToColor`
- 取得材質屬性：`TryGetFloat`、`TryGetColor`、`TryGetTexture`
- 設定材質屬性：`TrySetFloat`、`TrySetColor`、`TrySetTexture`

---

每個功能分類中的函式都設計簡單易用，能有效提升開發效率，適用於各類場景開發。更多使用細節請參考以下的範例或完整文件。

## 使用範例

### Component Extensions

1. `Restart`
```csharp
public static void Restart(this Behaviour behaviour)
```
```csharp
var behaviour = GetComponent<MonoBehaviour>();
behaviour.Restart(); // 重新啟動該行為腳本
```

---

### GameObject Extensions

1. `Instantiate`
```csharp
public static TSource Instantiate<TSource>(this TSource source) where TSource : Object
```
```csharp
var instance = prefab.Instantiate(); // 動態生成 prefab，並將其放置在場景中
instance.transform.position = new Vector3(0, 0, 0);
```

2. `TryAddComponent`
```csharp
public static TSource TryAddComponent<TSource>(this GameObject gameObject) where TSource : Component
```
```csharp
var collider = gameObject.TryAddComponent<BoxCollider>(); // 嘗試新增 BoxCollider 組件
collider.size = new Vector3(1, 1, 1);
```

3. `SetSizeWithCurrentAnchors`
```csharp
public static void SetSizeWithCurrentAnchors(this RectTransform rectTransform, float width, float height)
```
```csharp
uiElement.SetSizeWithCurrentAnchors(200f, 100f); // 設置寬 200、高 100
```

---

### Visual Extensions

1. `GetStateInfo`
```csharp
public static AnimatorStateInfo GetStateInfo(this Animator animator, int layer)
```
```csharp
var stateInfo = animator.GetStateInfo(0); // 獲取第 0 層的動畫狀態資訊
if (stateInfo.IsName("Run"))
{
    // 根據動畫名稱執行相應邏輯
}
```

2. `Wait`
```csharp
public static IEnumerator Wait(this Animator animator)
```
```csharp
private IEnumerator PerformAnimation()
{
    animator.SetTrigger("play");
    yield return animator.Wait();  // 等待動畫完成
    
    // 動畫完成後的邏輯
}
```

3. `ToColor`
```csharp
public static Color ToColor(this string hex)
```
```csharp
string hexColor = "#FFFFFF";
Color color = hexColor.ToColor(); // 使用 16 進位字串設置顏色
```

## 文件說明
每個擴充方法都包含詳細的 XML 註解，提供方法的用途、參數及回傳值說明。您可透過 Visual Studio 的 IntelliSense 或其他 IDE 查看詳細資訊，提升開發效率。

## 授權
此專案基於 GPLv3 授權條款，詳情請參閱 LICENSE 文件。
