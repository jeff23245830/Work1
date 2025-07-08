function Delete(url) {
            Swal.fire({
                title: '確定要刪除嗎?',
                text: "刪除後將無法恢復！",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: '是的，刪除它!',
                cancelButtonText: '取消'
            }).then((result) => {
                if (result.isConfirmed) {
                    // 使用 fetch 或 jQuery.ajax 發送 DELETE 請求
                    fetch(url, {
                        method: 'DELETE', // 或者 'POST' 如果你的後端 Delete action 是 POST
                        headers: {
                            'Content-Type': 'application/json'
                            // 如果有 anti-forgery token，也需要在這裡添加
                        }
                    })
                    .then(response => {
                        if (response.ok) {
                            Swal.fire(
                                '已刪除!',
                                '您的項目已被刪除。',
                                'success'
                            ).then(() => {
                                location.reload(); // 重新載入頁面或更新列表
                            });
                        } else {
                            Swal.fire(
                                '錯誤!',
                                '刪除失敗，請稍後再試。',
                                'error'
                            );
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        Swal.fire(
                            '錯誤!',
                            '請求失敗。',
                            'error'
                        );
                    });
                }
            })
        }


