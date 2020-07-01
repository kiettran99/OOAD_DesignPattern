use QuanLyCaPhe

drop index if exists Index_TimThucAn on ThucAn

create unique index Index_TimThucAn
on ThucAn(TenThucAn)
include(IDThucAn, IDLoaiThucAn, Gia)

select * from ThucAn where TenThucAn like 'Xoài'