# -*- coding: utf-8 -*-
"""
Script tạo dữ liệu mẫu chuyến bay tháng 12/2025 cho Airplace2025
"""

import pandas as pd
import random
from datetime import datetime, timedelta

# ============ DỮ LIỆU MASTER TỪ DATABASE ============

# Sân bay
AIRPORTS = ['VCS', 'UIH', 'CAH', 'VCA', 'BMV', 'DAD', 'DIN', 'PXU', 'HPH', 
            'HAN', 'SGN', 'CXR', 'VKG', 'PQC', 'DLI', 'VII', 'TBB', 'VDH', 
            'VCL', 'THD', 'HUI']

# Sân bay chính (nhiều chuyến bay hơn)
MAIN_AIRPORTS = ['SGN', 'HAN', 'DAD', 'CXR', 'PQC', 'HPH', 'VCA', 'VII', 'HUI']

# Máy bay với số ghế
AIRPLANES = {
    'VN-A351': {'seats': 305, 'airline': 'VN'},
    'VN-A868': {'seats': 283, 'airline': 'VN'},
    'VN-A321': {'seats': 203, 'airline': 'VN'},
    'VN-A320': {'seats': 180, 'airline': 'VN'},
    'VJ-A321': {'seats': 220, 'airline': 'VJ'},
    'VJ-A320': {'seats': 188, 'airline': 'VJ'},
    'VJ-A330': {'seats': 377, 'airline': 'VJ'},
    'QH-A321': {'seats': 203, 'airline': 'QH'},
    'QH-B789': {'seats': 300, 'airline': 'QH'},
    'QH-E190': {'seats': 98, 'airline': 'QH'},
    'VU-A321': {'seats': 200, 'airline': 'VU'},
}

# Trạng thái
STATUSES = ['Theo lịch trình', 'Theo lịch trình', 'Theo lịch trình', 
            'Theo lịch trình', 'Theo lịch trình', 'Bị hoãn']

# Khoảng cách bay (phút) giữa các sân bay chính
FLIGHT_TIMES = {
    ('SGN', 'HAN'): (120, 135),
    ('HAN', 'SGN'): (115, 130),
    ('SGN', 'DAD'): (75, 90),
    ('DAD', 'SGN'): (70, 85),
    ('HAN', 'DAD'): (70, 85),
    ('DAD', 'HAN'): (75, 90),
    ('SGN', 'CXR'): (55, 70),
    ('CXR', 'SGN'): (50, 65),
    ('SGN', 'PQC'): (55, 65),
    ('PQC', 'SGN'): (50, 60),
    ('HAN', 'CXR'): (100, 115),
    ('CXR', 'HAN'): (105, 120),
    ('SGN', 'HPH'): (110, 125),
    ('HPH', 'SGN'): (105, 120),
    ('SGN', 'VCA'): (45, 55),
    ('VCA', 'SGN'): (40, 50),
    ('HAN', 'VII'): (50, 65),
    ('VII', 'HAN'): (45, 60),
    ('SGN', 'DLI'): (45, 60),
    ('DLI', 'SGN'): (40, 55),
    ('SGN', 'HUI'): (75, 90),
    ('HUI', 'SGN'): (70, 85),
    ('HAN', 'HUI'): (65, 80),
    ('HUI', 'HAN'): (60, 75),
    ('SGN', 'BMV'): (55, 70),
    ('BMV', 'SGN'): (50, 65),
}

# Giá cơ bản (VND) theo khoảng cách
def get_base_price(flight_time):
    if flight_time < 60:
        return random.randint(650000, 900000)
    elif flight_time < 90:
        return random.randint(900000, 1200000)
    elif flight_time < 120:
        return random.randint(1100000, 1500000)
    else:
        return random.randint(1400000, 1800000)

def get_flight_time(dep, arr):
    """Lấy thời gian bay giữa 2 sân bay"""
    key = (dep, arr)
    if key in FLIGHT_TIMES:
        return random.randint(*FLIGHT_TIMES[key])
    # Default cho các tuyến khác
    return random.randint(60, 120)

def distribute_seats(total_seats, plane_type):
    """Phân bổ ghế theo hạng vé"""
    # Máy bay nhỏ (E190) chỉ có Economy và Business
    if total_seats < 120:
        eco = int(total_seats * 0.88)
        bus = total_seats - eco
        return eco, bus, 0, 0
    
    # Máy bay vừa (A320, A321)
    if total_seats < 250:
        eco = int(total_seats * 0.80)
        bus = int(total_seats * 0.12)
        pre = total_seats - eco - bus
        return eco, bus, 0, pre
    
    # Máy bay lớn (A350, B787, A330)
    eco = int(total_seats * 0.75)
    bus = int(total_seats * 0.10)
    fir = int(total_seats * 0.05)
    pre = total_seats - eco - bus - fir
    return eco, bus, fir, pre

def generate_stopover(dep, arr):
    """Tạo điểm dừng trung gian nếu cần"""
    # Chỉ các chuyến bay dài mới có trung gian
    long_routes = [
        ('SGN', 'HAN'), ('HAN', 'SGN'),
        ('SGN', 'HPH'), ('HPH', 'SGN'),
        ('HAN', 'CXR'), ('CXR', 'HAN'),
        ('HAN', 'PQC'), ('PQC', 'HAN'),
    ]
    
    if (dep, arr) not in long_routes:
        return None, None
    
    # 30% chuyến bay có trung gian
    if random.random() > 0.3:
        return None, None
    
    # Chọn sân bay trung gian hợp lý
    stopovers_map = {
        ('SGN', 'HAN'): ['DAD', 'HUI', 'VII'],
        ('HAN', 'SGN'): ['DAD', 'HUI', 'VII'],
        ('SGN', 'HPH'): ['DAD', 'HUI'],
        ('HPH', 'SGN'): ['DAD', 'HUI'],
        ('HAN', 'CXR'): ['DAD', 'HUI'],
        ('CXR', 'HAN'): ['DAD', 'HUI'],
        ('HAN', 'PQC'): ['SGN', 'VCA'],
        ('PQC', 'HAN'): ['SGN', 'VCA'],
    }
    
    possible_stops = stopovers_map.get((dep, arr), [])
    if not possible_stops:
        return None, None
    
    stop1 = random.choice(possible_stops)
    stop1_data = {
        'airport': stop1,
        'duration': random.randint(30, 60),  # Thời gian dừng
        'transit': random.randint(45, 80),   # Thời gian bay tới trung gian
        'note': random.choice(['Đón/trả khách', 'Tiếp nhiên liệu', 'Đón khách'])
    }
    
    # 10% có 2 điểm dừng
    if random.random() < 0.1 and len(possible_stops) > 1:
        remaining = [s for s in possible_stops if s != stop1]
        stop2 = random.choice(remaining)
        stop2_data = {
            'airport': stop2,
            'duration': random.randint(30, 50),
            'transit': random.randint(40, 70),
            'note': random.choice(['Trả khách', 'Đón khách thêm'])
        }
        return stop1_data, stop2_data
    
    return stop1_data, None

def generate_flights_data():
    """Tạo dữ liệu chuyến bay"""
    flights = []
    
    # Tuyến bay phổ biến
    popular_routes = [
        ('SGN', 'HAN'), ('HAN', 'SGN'),
        ('SGN', 'DAD'), ('DAD', 'SGN'),
        ('HAN', 'DAD'), ('DAD', 'HAN'),
        ('SGN', 'CXR'), ('CXR', 'SGN'),
        ('SGN', 'PQC'), ('PQC', 'SGN'),
        ('HAN', 'CXR'), ('CXR', 'HAN'),
        ('SGN', 'HPH'), ('HPH', 'SGN'),
        ('SGN', 'VCA'), ('VCA', 'SGN'),
        ('HAN', 'VII'), ('VII', 'HAN'),
        ('SGN', 'DLI'), ('DLI', 'SGN'),
        ('SGN', 'HUI'), ('HUI', 'SGN'),
        ('HAN', 'HUI'), ('HUI', 'HAN'),
        ('SGN', 'BMV'), ('BMV', 'SGN'),
    ]
    
    # Thời gian khởi hành phổ biến
    departure_times = [
        (6, 0), (6, 30), (7, 0), (7, 30), (8, 0), (8, 30),
        (9, 0), (9, 30), (10, 0), (10, 30), (11, 0), (11, 30),
        (12, 30), (13, 0), (13, 30), (14, 0), (14, 30),
        (15, 0), (15, 30), (16, 0), (16, 30), (17, 0),
        (18, 0), (18, 30), (19, 0), (19, 30), (20, 0), (20, 30),
        (21, 0), (21, 30)
    ]
    
    flight_id = 0
    
    # Tạo chuyến bay cho mỗi ngày trong tháng 12
    for day in range(1, 32):
        # Số chuyến bay mỗi ngày (nhiều hơn vào cuối tuần và lễ)
        if day in [24, 25, 30, 31]:  # Lễ Giáng sinh và Tết
            num_flights_today = random.randint(12, 16)
        elif day % 7 in [0, 6]:  # Cuối tuần
            num_flights_today = random.randint(8, 12)
        else:
            num_flights_today = random.randint(4, 8)
        
        used_times = set()  # Tránh trùng giờ bay
        
        for _ in range(num_flights_today):
            flight_id += 1
            
            # Chọn tuyến bay
            route = random.choice(popular_routes)
            dep, arr = route
            
            # Chọn máy bay
            plane = random.choice(list(AIRPLANES.keys()))
            plane_info = AIRPLANES[plane]
            
            # Chọn giờ bay
            time_idx = random.randint(0, len(departure_times) - 1)
            while time_idx in used_times and len(used_times) < len(departure_times):
                time_idx = random.randint(0, len(departure_times) - 1)
            used_times.add(time_idx)
            
            hour, minute = departure_times[time_idx]
            flight_datetime = datetime(2025, 12, day, hour, minute)
            
            # Thời gian bay
            flight_time = get_flight_time(dep, arr)
            
            # Giá cơ bản
            base_price = get_base_price(flight_time)
            
            # Phân bổ ghế
            total_seats = plane_info['seats']
            eco, bus, fir, pre = distribute_seats(total_seats, plane)
            
            # Trạng thái
            status = random.choice(STATUSES)
            
            # Điểm dừng trung gian
            stop1, stop2 = generate_stopover(dep, arr)
            
            flight = {
                'MaMayBay': plane,
                'SanBayDi': dep,
                'SanBayDen': arr,
                'NgayGioBay': flight_datetime.strftime('%d/%m/%Y %H:%M'),
                'ThoiGianBay': flight_time,
                'GiaCoBan': base_price,
                'SL_Eco': eco,
                'SL_Bus': bus,
                'SL_Fir': fir,
                'SL_Pre': pre,
                'TG1_MaSanBay': stop1['airport'] if stop1 else '',
                'TG1_ThoiGianDung': stop1['duration'] if stop1 else '',
                'TG1_ThoiGianChuyen': stop1['transit'] if stop1 else '',
                'TG1_GhiChu': stop1['note'] if stop1 else '',
                'TG2_MaSanBay': stop2['airport'] if stop2 else '',
                'TG2_ThoiGianDung': stop2['duration'] if stop2 else '',
                'TG2_ThoiGianChuyen': stop2['transit'] if stop2 else '',
                'TG2_GhiChu': stop2['note'] if stop2 else '',
                'TrangThai': status,
            }
            
            flights.append(flight)
    
    return flights

def main():
    print("Đang tạo dữ liệu chuyến bay tháng 12/2025...")
    
    flights = generate_flights_data()
    
    # Tạo DataFrame
    df = pd.DataFrame(flights)
    
    # Đổi tên cột theo thứ tự trong code C#
    columns_order = [
        'MaMayBay',      # Cột 1
        'SanBayDi',      # Cột 2
        'SanBayDen',     # Cột 3
        'NgayGioBay',    # Cột 4
        'ThoiGianBay',   # Cột 5
        'GiaCoBan',      # Cột 6
        'SL_Eco',        # Cột 7
        'SL_Bus',        # Cột 8
        'SL_Fir',        # Cột 9
        'SL_Pre',        # Cột 10
        'TG1_MaSanBay',  # Cột 11
        'TG1_ThoiGianDung',   # Cột 12
        'TG1_ThoiGianChuyen', # Cột 13
        'TG1_GhiChu',    # Cột 14
        'TG2_MaSanBay',  # Cột 15
        'TG2_ThoiGianDung',   # Cột 16
        'TG2_ThoiGianChuyen', # Cột 17
        'TG2_GhiChu',    # Cột 18
        'TrangThai',     # Cột 19
    ]
    
    df = df[columns_order]
    
    # Xuất ra file Excel
    output_file = 'ds_chuyenbay_thang12.xlsx'
    df.to_excel(output_file, index=False, engine='openpyxl')
    
    print(f"Đã tạo thành công {len(flights)} chuyến bay!")
    print(f"File: {output_file}")
    
    # Hiển thị thống kê
    print("\n=== THỐNG KÊ ===")
    print(f"Tổng số chuyến bay: {len(flights)}")
    print(f"\nTheo hãng bay:")
    for airline in ['VN', 'VJ', 'QH', 'VU']:
        count = len([f for f in flights if f['MaMayBay'].startswith(airline)])
        print(f"  {airline}: {count} chuyến")
    
    print(f"\nTheo sân bay đi (top 5):")
    dep_counts = df['SanBayDi'].value_counts().head(5)
    for airport, count in dep_counts.items():
        print(f"  {airport}: {count} chuyến")
    
    print(f"\nChuyến có trung gian: {len([f for f in flights if f['TG1_MaSanBay']])}")

if __name__ == "__main__":
    main()

