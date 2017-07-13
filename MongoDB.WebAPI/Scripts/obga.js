if (!jQuery) { throw new Error("OBGA requires jQuery") }

var domain = "http://localhost:54076/api/";
function postobgamdb(func, data) {
    switch (func)
    {
        case "1": // 查看內容
            $.post(domain + "ViewContent", data);
            break
        case "2": // 搜尋
            $.post(domain + "Search", data);
            break
        case "3": // 加到購物車
            $.post(domain + "AddToCart", data);
            break
        case "4": // 加到願望清單
            $.post(domain + "AddToWishlist", data);
            break
        case "5": // 開始結帳
            $.post(domain + "InitiateCheckout", data);
            break
        case "6": // 新增付款資料
            $.post(domain + "AddPaymentInfo", data);
            break
        case "7": // 購買
            $.post(domain + "Purchase", data);
            break
        case "8": // 潛在顧客
            $.post(domain + "Lead", data);
            break
        case "9": // 完成註冊
            $.post(domain + "CompleteRegistration", data);
            break
    }
}