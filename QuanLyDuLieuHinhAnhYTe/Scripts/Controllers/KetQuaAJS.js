/// <reference path="../angular-1.3.9/angular.js" />

var app = angular.module("AppKetQuaModule", ['angularUtils.directives.dirPagination', 'ngFileUpload', 'ui.bootstrap']);

app.controller("KetQuaController", function ($scope, $rootScope, $http, Upload) {

    $http.get('/QuanLyKetQua/GetBenhNhan').then(function (d) {
        $rootScope.listBenhNhan = d.data;
    }, function (e) { alert("Lỗi lấy dữ liệu"); });

    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/QuanLyKetQua/Upload',
                data: { files: $scope.SelectedFiles, MaKetQua: $scope.b.MaKetQua }
            }).then(function (d) {
                $scope.b.HinhAnh = d.data[0];
            }, function (e) { alert("Lỗi"); });
        }
    }
    $rootScope.searchText = "";
    $scope.maxSize = 5;     // Limit number for pagination display number.
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 5; // Maximum number of items per page.  

    $scope.GetKetQuaList = function () {
        $http.get("https://localhost:44310/QuanLyKetQua/GetKetQua?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListKetQua = response.data.KetQuas;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetKetQuaList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetKetQuaList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetKetQuaList();
    };



    //$scope.Them = function () {
    //    $scope._function = "Thêm kết quả";
    //    $scope.buttext = "Save";
    //    $scope.b = null;
    //};

    $scope.Sua = function (b) {
        $scope.b = b;
    };


    $scope.Save = function () {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/QuanLyKetQua/Insert',
            data: JSON.stringify($scope.b)
        }).then(function (d) {
            //alert($scope.s.MaSP);
            if (d.data == "") {
                $scope.ListKetQua.push($scope.b);
                $scope.b = null;
                alert("Data Submitted...!");
            }
            else {
                alert(d.data);
            }
        }, function (e) {
            alert("Lỗi nhập...!");
        });
    }
    $scope.Update = function () {
        $http({
            method: 'Post',
            datatype: 'Json',
            data: JSON.stringify($scope.b),
            url: '/QuanLyKetQua/Update'
        }).then(function (d) {
            if (d.data == "") {
                var index = $scope.ListKetQua;
                for (var i = 0; i < $scope.ListKetQua.length; i++) {
                    //Sửa thành công thì tiến hành sửa trên $scope
                    if ($scope.ListKetQua[i].MaKetQua == $scope.b.MaKetQua) {
                        $scope.ListKetQua[i].MaBenhNhan = $scope.b.MaBenhNhan;
                        $scope.ListKetQua[i].LanChup = $scope.b.LanChup;
                        $scope.ListKetQua[i].HinhAnh = $scope.b.HinhAnh;
                        $scope.ListKetQua[i].MucDich = $scope.b.MucDich;
                        $scope.ListKetQua[i].KyThuat = $scope.b.KyThuat;
                        $scope.ListKetQua[i].KetLuan = $scope.b.KetLuan;
                        break;
                    }
                }
                alert("Update success...!")
            }
        }, function (e) { alert(e); });
    }



    //$scope.Save = function () {
    //    //Sửa thông tin Kết quả
    //    if ($scope.buttext != "Save") {
    //        $http({
    //            method: 'Post',
    //            datatype: 'Json',
    //            data: JSON.stringify($scope.b),
    //            url: '/QuanLyKetQua/Update'
    //        }).then(function (d) {
    //            if (d.data == "") {
    //                var index = $scope.ListKetQua;
    //                for (var i = 0; i < $scope.ListKetQua.length; i++) {
    //                    //Sửa thành công thì tiến hành sửa trên $scope
    //                    if ($scope.ListKetQua[i].MaKetQua == $scope.b.MaKetQua) {
    //                        $scope.ListKetQua[i].MaBenhNhan = $scope.b.MaBenhNhan;
    //                        $scope.ListKetQua[i].LanChup = $scope.b.LanChup;
    //                        $scope.ListKetQua[i].HinhAnh = $scope.b.HinhAnh;
    //                        $scope.ListKetQua[i].MucDich = $scope.b.MucDich;
    //                        $scope.ListKetQua[i].KyThuat = $scope.b.KyThuat;
    //                        $scope.ListKetQua[i].KetLuan = $scope.b.KetLuan;
    //                        break;
    //                    }
    //                }
    //                alert("Update success...!")
    //            }
    //        }, function (e) { alert(e); });
    //    }
    //    else //Thêm bệnh nhân
    //    {
    //        $http({
    //            method: 'POST',
    //            datatype: 'json',
    //            url: '/QuanLyKetQua/Insert',
    //            data: JSON.stringify($scope.b)
    //        }).then(function (d) {
    //            //alert($scope.s.MaSP);
    //            if (d.data == "") {
    //                $scope.ListKetQua.push($scope.b);
    //                $scope.b = null;
    //                alert("Data Submitted...!");
    //            }
    //            else {
    //                alert(d.data);
    //            }
    //        }, function (e) {
    //            alert("Lỗi nhập...!");
    //        });
    //    }
    //};

    $scope.XoaKetQua = function (b) {
        $http({
            method: 'Post',
            url: '/QuanLyKetQua/Delete',
            datatype: 'Json',
            data: { id: b.MaKetQua }
        }).then(function (d) {
            alert("Bạn có chắc chắn muốn xóa không?");
            var vt = $scope.ListKetQua.indexOf(b);
            $scope.ListKetQua.splice(vt, 1);
        }, function (e) { alert(e) });
    };
});

app.controller("DetailController", function ($scope, $rootScope, $http) {
    $rootScope.searchText = "";
    $scope.maxSize = 5;     // Limit number for pagination display number.
    $scope.totalCount = 0;  // Total number of items in all pages. initialize as a zero  
    $scope.pageIndex = 1;   // Current page number. First page is 1.-->  
    $scope.pageSizeSelected = 5; // Maximum number of items per page.  

    $scope.GetKetQuaList = function () {
        $http.get("https://localhost:44310/QuanLyKetQua/GetKetQuaByMaBN?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListKetQua = response.data.KetQuas;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetKetQuaList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetKetQuaList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetKetQuaList();
    };
});