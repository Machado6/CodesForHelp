function FormatarData(data) {
    var jsData = eval(data.replace(/\/Date\((\d+)\)\//gi, "new Date($1)"));
    var dataFormatada = jsData.toLocaleDateString();
 
    return dataFormatada;
};