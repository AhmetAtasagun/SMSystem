'use client';

import { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { fetchProducts } from '@/redux/slices/productSlice';
import Link from 'next/link';

export default function ProductsPage() {
  const dispatch = useDispatch<AppDispatch>();
  const { products, loading, error, totalCount } = useSelector((state: RootState) => state.products);
  const [searchTerm, setSearchTerm] = useState('');
  const [currentPage, setCurrentPage] = useState(1);
  const pageSize = 10;

  useEffect(() => {
    dispatch(fetchProducts());
  }, [dispatch]);

  const handleSearch = (e: React.FormEvent) => {
    e.preventDefault();
    // Implement search functionality here
    dispatch(fetchProducts());
  };

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Ürünler</h1>
        <Link href="/dashboard/products/new" className="btn btn-primary">
          Yeni Ürün Ekle
        </Link>
      </div>

      <div className="card">
        <form onSubmit={handleSearch} className="flex gap-2 mb-4">
          <input
            type="text"
            placeholder="Ürün ara..."
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
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Ürün Adı</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Kategori</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Fiyat</th>
                    <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">İşlemler</th>
                  </tr>
                </thead>
                <tbody className="bg-white divide-y divide-gray-200">
                  {products.length > 0 ? (
                    products.map((product) => (
                      <tr key={product.id}>
                        <td className="px-6 py-4 whitespace-nowrap">{product.name}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{product.categoryName}</td>
                        <td className="px-6 py-4 whitespace-nowrap">{product.price.toFixed(2)} TL</td>
                        <td className="px-6 py-4 whitespace-nowrap space-x-2">
                          <Link href={`/dashboard/products/${product.id}`} className="text-primary-600 hover:text-primary-900">
                            Detay
                          </Link>
                          <Link href={`/dashboard/products/${product.id}/edit`} className="text-yellow-600 hover:text-yellow-900">
                            Düzenle
                          </Link>
                        </td>
                      </tr>
                    ))
                  ) : (
                    <tr>
                      <td colSpan={4} className="px-6 py-4 text-center">
                        Ürün bulunamadı
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