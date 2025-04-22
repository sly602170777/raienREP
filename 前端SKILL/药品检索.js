var arr=[
    {
      yoho:'周一次 4枚',
      drugs:[
         {drugName:'药1',quantity:2},//单行药品信息
         {drugName:'药1',quantity:3}//单行药品信息
      ]
    },
    {
      yoho:'日2次 3枚',
      drugs:[
         {drugName:'药3',quantity:1},//单行药品信息
         {drugName:'药4',quantity:5}//单行药品信息
      ]
    },
   {
      yoho:'7',
      drugs:[
         {drugName:'药3',quantity:1},//单行药品信息
         {drugName:'药4',quantity:5}//单行药品信息
      ]
    },
    
   ];
   
   
   var groupCount = arr.filter(data=>data.yoho).length;
   
   // 最终的数据
   var resultData = [];
   for(var i = 0; i< groupCount; i++){
       resultData.push({yoho:'',drugs:[]});
   }
   
   //计数用
   var groupIndex = 0;
   arr.forEach((data,index)=>{
      resultData[groupIndex].drugs.push(data.drugs);
      if(data.yoho){
          resultData[groupIndex].yoho=data.yoho;
         groupIndex++;
      }
   
   })
   
   console.log(resultData);