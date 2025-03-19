'use client';

import { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { fetchSales } from '@/redux/slices/saleSlice';
import Link from 'next/link';

export default function SalesPage() {
  const dispatch = useDispatch<AppDispatch>();
  const { sales, loading, error, totalCount } = useSelector((state: RootState) => state.sales);
  const [searchTerm, setSearchTerm] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 10;

  useEffect(() => {
    dispatch(fetchSales({ page: currentPage, pageSize, search: searchTerm }));
  }, [dispatch, currentPage, pageSize]);

  const handleSearch = (e: React.FormEvent) => {
    e.preventDefault();
    setCurrentPage(1); // Reset to first page when searching
    dispatch(fetchSales({ page: 1, pageSize, search: searchTerm }));
  };

  const formatDate = (dateString: string) => {
    const date = new Date(dateString);
    return date.toLocaleDateString('tr-TR');
  };

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Satışlar</h1>
        <div className="space-x-2">
          <Link href="/dashboard/sales/new" className="btn btn-primary">
            Yeni Satış Ekle
          </Link>
          <Link href="/dashboard/sales/report" className="btn btn-secondary">
            Rapor İndir
          </Link>
        </div>
      </div>

      <div className="card">
        <form onSubmit={handleSearch} className="flex gap-2 mb-4">
          <input
            type="text"
            placeholder="Satış ara..."
            className="input flex-grow"
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
          />
          <button type="submit" className="btn btn-secondary">
            Ara
          </button>
        </form>

        {loading ? (
          <div className="text-center py-4">Yükleniyor...</div>
        ) : error ? (
          <div className="text-red-500 text-center py-4">{error}</div>
        ) : (
          <>
            <div className="overflow-x-auto">
              <table className="min-w-full divide-y divide-gray-200">
                <thead className="bg-gray-50">
                  <tr>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Tarih</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Ürün</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Müşteri</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Miktar</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Toplam Fiyat</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">İşlemler</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                  {sales.length > 0 ? (
                    sales.map((sale) => (
                      <tr key={sale.id}>
                        <td className="px-6 py-4 whitespace-nowrap">{formatDate(sale.saleDate)}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{sale.productName}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{sale.customerName}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{sale.quantity}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{sale.totalPrice.toFixed(2)} TL</td>
                        <td className="px-6 py-4 whitespace-nowrap space-x-2">
                          <Link href={`/dashboard/sales/${sale.id}`} className="text-primary-600 hover:text-primary-900">
                            Detay
                          </Link>
                        </td>
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td colSpan={6} className="px-6 py-4 text-center">
                        Satış bulunamadı
                      </td>
                    </tr>
                  )}
                </tbody>
              </table>
            </div>

            {totalCount > pageSize && (
              <div className="flex justify-center mt-4">
                <nav className="flex items-center space-x-2">
                  <button
                    onClick={() => setCurrentPage((prev) => Math.max(prev - 1, 1))}
                    disabled={currentPage === 1}
                    className="px-3 py-1 rounded border border-gray-300 disabled:opacity-50"
                  >
                    Önceki
                  </button>
                  <span className="text-sm">
                    Sayfa {currentPage} / {Math.ceil(totalCount / pageSize)}
                  </span>
                  <button
                    onClick={() => setCurrentPage((prev) => Math.min(prev + 1, Math.ceil(totalCount / pageSize)))}
                    disabled={currentPage >= Math.ceil(totalCount / pageSize)}
                    className="px-3 py-1 rounded border border-gray-300 disabled:opacity-50"
                  >
                    Sonraki
                  </button>
                </nav>
              </div>
            )}
          </>
        )}
      </div>
    </div>
  );
}