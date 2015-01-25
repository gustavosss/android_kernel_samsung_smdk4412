cat << CTAG
{
    name:I/O,
    elements:[
    { STitleBar:{
		title:"Internal Storage Settings"
	}},
	{ SOptionList:{
		title:"I/O Scheduler",
		default:sio,
		action:"bracket-option /sys/block/mmcblk0/queue/scheduler",
		values:[
`
			for IOSCHED in \`cat /sys/block/mmcblk0/queue/scheduler | sed -e 's/\]//;s/\[//'\`; do
			  echo "\"$IOSCHED\","
			done
`
		]
	}},
	{ SSeekBar:{
		title:"I/O read-ahead buffer",
		max:4096, min:128, unit:" kB", step:128,
		default:128,
                action:"generic /sys/devices/virtual/bdi/179:0/read_ahead_kb",
	}},
{ SPane:{
		title:"External Storage Settings"
	}},	
	{ SOptionList:{
		title:"I/O Scheduler",
		default:sio,
		action:"bracket-option /sys/block/mmcblk1/queue/scheduler",
		values:[
`
			for IOSCHED in \`cat /sys/block/mmcblk1/queue/scheduler | sed -e 's/\]//;s/\[//'\`; do
			  echo "\"$IOSCHED\","
			done
`
		]
	}},
	{ SSeekBar:{
		title:"I/O read-ahead buffer",
		max:4096, min:128, unit:" kB", step:128,
		default:128,
                action:"generic /sys/block/mmcblk1/queue/read_ahead_kb",
	}},
{ SPane:{
		title:"Dynamic Fsync"
	}},
{ SCheckBox:{
        label:"Dynamic Fsync",
        description:"Makes Fsync operation asynchronous with screen on, increasing speed but decreasing data integrity if a freeze happens or if battery is removed. With screen off, Fsync operation is synchronous.",
        default:0,
        action:"generic /sys/kernel/dyn_fsync/Dyn_fsync_active"
    }},
{ SPane:{
		title:"TRIM on boot"
	}},
{ SCheckBox:{
        label:"TRIM",
        description:"TRIM allows the operating system to inform a solid-state drive which blocks of data are no longer considered in use and can be wiped internally. When enabled, system, data, cache and preload partitions will be trimmed on every boot.",
        default:0,
        action:"generic /data/trim"
    }},
   ]
}

CTAG
