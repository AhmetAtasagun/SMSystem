'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from '@/redux/store';
import { downloadSalesReport } from '@/redux/slices/saleSlice';
import Link from 'next/link';

export default function SalesReportPage() {
  const router = useRouter();
  const dispatch = useDispatch<AppDispatch>();
  const { loading, error } = useSelector((state: RootState) => state.sales);
  
  const [startDate, setStartDate] = useState('');
  const [endDate, setEndDate] = useState('');
  const [reportGenerated, setReportGenerated] = useState(false);
  
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setReportGenerated(false);
    
    const result = await dispatch(downloadSalesReport({ startDate, endDate }));
    if (result.meta.requestStatus === 'fulfilled') {
      setReportGenerated(true);
    }
  };
  
  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Satış Raporu İndir</h1>
        <Link href="/dashboard/sales" className="btn btn-secondary">
          Geri Dön
        </Link>
      </div>
      
      <div className="card">
        {error && (
          <div className="bg-red-50 border border-red-200 text-red-700 px-4 py-3 rounded mb-4">
            {error}
          </div>
        )}
        
        {reportGenerated && (
          <div className="bg-green-50 border border-green-200 text-green-700 px-4 py-3 rounded mb-4">
            Rapor başarıyla indirildi.
          </div>
        )}
        
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div className="space-y-2">
              <label htmlFor="startDate" className="block font-medium">Başlangıç Tarihi</label>
              <input
                id="startDate"
                type="date"
                className="input"
                value={startDate}
                onChange={(e) => setStartDate(e.target.value)}
              />
            </div>
            
            <div className="space-y-2">
              <label htmlFor="endDate" className="block font-medium">Bitiş Tarihi</label>
              <input
                id="endDate"
                type="date"
                className="input"
                value={endDate}
                onChange={(e) => setEndDate(e.target.value)}
              />
            </div>
          </div>
          
          <div className="pt-4">
            <button 
              type="submit" 
              className="btn btn-primary w-full md:w-auto"
              disabled={loading}
            >
              {loading ? 'Rapor İndiriliyor...' : 'Excel Raporu İndir'}
            </button>
          </div>
        </form>
        
        <div className="mt-6 text-sm text-gray-600">
          <p>Not: Tarih aralığı belirtmezseniz, tüm satış verileri rapora dahil edilecektir.</p>
        </div>
      </div>
    </div>
  );
}