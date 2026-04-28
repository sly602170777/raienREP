var git = {
    //changeBorder 改变边框样式
    changeBorder: function () {
        console.log("123");
        document.getElementById('myTable').border="10";

    },
    //获取第一行第一个格子内容
    getCellFirst:function(){
      var cellOne = document.getElementById('myTable').rows[0].cells[0].innerHTML;
        console.log(cellOne);
    }
}