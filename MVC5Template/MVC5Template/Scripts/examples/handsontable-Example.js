var cols = 40,
      rows = 30,
      i, j, len,
      data2 = [];

for (i = 0; i < rows; i++) {
    data2[i] = [];
    for (j = 0; j < cols; j++) {
        data2[i].push(j + 1);
    }
}

var container2 = document.getElementById('example1'),
    hot;

hot = new Handsontable(container2, {
    data: data2,
    colHeaders: true,
    rowHeaders: true
});

var ex = document.getElementById('example1');
table = ex.querySelectorAll('table');

function findAncestor(el, cls) {
    while ((el = el.parentElement) && !el.classList.contains(cls)) {
        return el;
    }

}

for (i = 0, len = table.length; i < len; i++) {
    var tableInstance = table[i];
    var isMaster = !!findAncestor(tableInstance, 'ht_master');

    Handsontable.Dom.addClass(tableInstance, 'table');
    Handsontable.Dom.addClass(tableInstance, 'table-hover');
    Handsontable.Dom.addClass(tableInstance, 'table-striped');

    if (isMaster) {
        Handsontable.Dom.addClass(tableInstance, 'table-bordered');
    }
}

$('#example1').perfectScrollbar();

