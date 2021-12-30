/// <reference path="../angular-1.3.9/angular.js" />

var app = angular.module("AppModule", ['angularUtils.directives.dirPagination', 'ngFileUpload', 'ui.bootstrap']);

app.controller("BenhNhanController", function ($scope, $rootScope, $http, Upload) {
    $scope.UploadFiles = function (files) {
        $scope.SelectedFiles = files;
        if ($scope.SelectedFiles && $scope.SelectedFiles.length) {
            Upload.upload({
                url: '/QuanLyBenhNhan/Upload',
                data: { files: $scope.SelectedFiles, MaBenhNhan: $scope.b.MaBenhNhan }
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

    $scope.GetBenhNhanList = function () {
        $http.get("https://localhost:44310/QuanLyBenhNhan/GetBenhNhan?pageIndex=" + $scope.pageIndex + "&pageSize=" + $scope.pageSizeSelected).then(
            function (response) {
                $scope.ListBenhNhan = response.data.BenhNhans;
                $scope.totalCount = response.data.totalCount;
            },
            function (err) {
                var error = err;
            });
    }

    //Loading employees list on first time  
    $scope.GetBenhNhanList();

    //This method is calling from pagination number  
    $scope.pageChanged = function () {
        $scope.GetBenhNhanList();
    };

    //This method is calling from dropDown  
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.GetBenhNhanList();
    };



    //$scope.Them = function () {
    //    $scope._function = "Thêm bệnh nhân";
    //    $scope.buttext = "Save";
    //    $scope.b = null;
    //};

    $scope.Sua = function (b) {
      
            $scope.b = b;
        
    };

    //$scope.Save = function () {
    //    //Sửa thông tin bệnh nhân
    //    if ($scope.buttext != "Save") {
    //        $http({
    //            method: 'Post',
    //            datatype: 'Json',
    //            data: JSON.stringify($scope.b),
    //            url: '/QuanLyBenhNhan/Update'
    //        }).then(function (d) {
    //            if (d.data == "") {
    //                var index = $scope.ListBenhNhan;
    //                for (var i = 0; i < $scope.ListBenhNhan.length; i++) {
    //                    //Sửa thành công thì tiến hành sửa trên $scope
    //                    if ($scope.ListBenhNhan[i].MaBenhNhan == $scope.b.MaBenhNhan) {
    //                        $scope.ListBenhNhan[i].HoTen = $scope.b.HoTen;
    //                        $scope.ListBenhNhan[i].NamSinh = $scope.b.NamSinh;
    //                        $scope.ListBenhNhan[i].GioiTinh = $scope.b.GioiTinh;
    //                        $scope.ListBenhNhan[i].DanToc = $scope.b.DanToc;
    //                        $scope.ListBenhNhan[i].MaSoBHXH_BHYT = $scope.b.MaSoBHXH_BHYT;
    //                        $scope.ListBenhNhan[i].DonViCongTac = $scope.b.DonViCongTac;
    //                        $scope.ListBenhNhan[i].DiaChi = $scope.b.DiaChi;
    //                        $scope.ListBenhNhan[i].VaoVien = $scope.b.VaoVien;
    //                        $scope.ListBenhNhan[i].RaVien = $scope.b.RaVien;
    //                        $scope.ListBenhNhan[i].ChanDoanVaoVien = $scope.b.ChanDoanVaoVien;
    //                        $scope.ListBenhNhan[i].ChanDoanRaVien = $scope.b.ChanDoanRaVien;
    //                        $scope.ListBenhNhan[i].TomTatBenhAn = $scope.b.TomTatBenhAn;
    //                        $scope.ListBenhNhan[i].HinhAnh = $scope.b.HinhAnh;
    //                        $scope.ListBenhNhan[i].GhiChu = $scope.b.GhiChu;
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
    //            url: '/QuanLyBenhNhan/Insert',
    //            data: JSON.stringify($scope.b)
    //        }).then(function (d) {
    //            //alert($scope.s.MaSP);
    //            if (d.data == "") {
    //                $scope.ListBenhNhan.push($scope.b);
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
    $scope.Save = function () {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/QuanLyBenhNhan/Insert',
            data: JSON.stringify($scope.b)
        }).then(function (d) {
            if (d.data == "") {
                $scope.ListBenhNhan.push($scope.b);
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
            url: '/QuanLyBenhNhan/Update'
        }).then(function (d) {
            if (d.data == "") {
                var index = $scope.ListBenhNhan;
                for (var i = 0; i < $scope.ListBenhNhan.length; i++) {
                    //Sửa thành công thì tiến hành sửa trên $scope
                    if ($scope.ListBenhNhan[i].MaBenhNhan == $scope.b.MaBenhNhan) {
                        $scope.ListBenhNhan[i].HoTen = $scope.b.HoTen;
                        $scope.ListBenhNhan[i].NamSinh = $scope.b.NamSinh;
                        $scope.ListBenhNhan[i].GioiTinh = $scope.b.GioiTinh;
                        $scope.ListBenhNhan[i].DanToc = $scope.b.DanToc;
                        $scope.ListBenhNhan[i].MaSoBHXH_BHYT = $scope.b.MaSoBHXH_BHYT;
                        $scope.ListBenhNhan[i].DonViCongTac = $scope.b.DonViCongTac;
                        $scope.ListBenhNhan[i].DiaChi = $scope.b.DiaChi;
                        $scope.ListBenhNhan[i].VaoVien = $scope.b.VaoVien;
                        $scope.ListBenhNhan[i].RaVien = $scope.b.RaVien;
                        $scope.ListBenhNhan[i].ChanDoanVaoVien = $scope.b.ChanDoanVaoVien;
                        $scope.ListBenhNhan[i].ChanDoanRaVien = $scope.b.ChanDoanRaVien;
                        $scope.ListBenhNhan[i].TomTatBenhAn = $scope.b.TomTatBenhAn;
                        $scope.ListBenhNhan[i].HinhAnh = $scope.b.HinhAnh;
                        $scope.ListBenhNhan[i].GhiChu = $scope.b.GhiChu;
                        break;
                    }
                }
                alert("Update success...!")
            }
        }, function (e) { alert(e); });
    }


    $scope.XoaBenhNhan = function (b) {
        $http({
            method: 'Post',
            url: '/QuanLyBenhNhan/Delete',
            datatype: 'Json',
            data: { id: b.MaBenhNhan }
        }).then(function (d) {
            alert("Bạn có chắc chắn muốn xóa không?");
            var vt = $scope.ListBenhNhan.indexOf(b);
            $scope.ListBenhNhan.splice(vt, 1);
        }, function (e) { alert(e) });
    };
});



